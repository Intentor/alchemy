/****************************************
Intentor.Alchemy
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using System.Diagnostics;

namespace Intentor.Alchemy
{
    /// <summary>
    ///     Contém métodos de apoio no gerenciamento de exceções.
    /// </summary>
    public static class ExceptionHandlingHelper
    {
        #region Métodos

        #region Private

        /// <summary>
        ///     Envia o erro para o webservice principal.
        /// </summary>
        /// <param name="ex">
        ///     Exceção ocorrida.
        /// </param>
        /// <param name="config">
        ///     Configurações do componente.
        /// </param>
        /// <returns>
        ///     Retorna valor booleano indicando se se deve limpar
        ///     o(s) erro(s) ocorrido ou não.
        /// </returns>
        private static bool ParseException(Exception ex,
            AlchemyConfigurationSection config)
        {
            #region Declaração de objetos

            bool cleanErrors = false;
            List<ExceptionInfo> infos = new List<ExceptionInfo>();

            #endregion

            //Para cada exceção, cria objeto ExceptionInfo.
            for (Exception e = ex; ex.InnerException != null; e = ex.InnerException)
            {
                MethodBase method = e.TargetSite;

                //TODO: Analisar procedimento para armazenamento de erro 404.
                /*
                 * if (exception is HttpException && ((HttpException)exception).ErrorCode == 404) {
                logger.Warn("A 404 occurred", exception);
                 */

                #region Checagem de atributos

                //Não armazena exceção para o método "HandleError".
                if (method.Name == "HandleError") continue;

                /* Caso não "cleanErros" seja "false", verifica se é para ocorrer
                 * limpeza do erro. */
                if (!cleanErrors) cleanErrors = CheckForErrorCleaning(method);

                /* Não armazena exceção para métodos ou classes nas quais os métodos
                 * possuam o atributo "CheckSkipExceptions". 
                 * Tal verificação é realizada após os nomes de métodos a serem ignorados
                 * por conta dos procedimentos de limpeza de erros, que devem ser validados
                 * antes. */
                if (CheckSkipExceptions(method)) continue;

                #endregion

                #region População do objeto ExceptionInfo

                ExceptionInfo info = new ExceptionInfo(config.ApplicationName
                    , config.ApplicationVersion
                    , ex.Message);

                info.Criticality = (short)GetCriticality(method);
                info.Logs = Log.GetLogs();
                info.Source = e.Source;
                info.MethodName = method.Name;
                info.StackTrace = e.StackTrace;

                #endregion

                infos.Add(info);
            }

            //Se a lista de exceções contiver algum item, envia-os.
            if (infos.Count > 0)
            {
                using (AnalysisServiceHelper wsHelper =
                    new AnalysisServiceHelper(config.WebServiceAddress))
                {
                    wsHelper.SendExceptions(infos);
                }
            }

            return cleanErrors;
        }     

        #region Checagem de atributos

        /// <summary>
        ///     Obtém a criticidade de um método.
        /// </summary>
        /// <param name="method">
        ///     Objeto <see cref="MethodInfo"/> que representa o método a 
        ///     ser verificado.
        /// </param>
        /// <returns>
        ///     Retorna a criticidade obtida.
        /// </returns>
        private static MethodCriticality GetCriticality(MethodBase method)
        {
            MethodCriticality crit = MethodCriticality.NotInformed;

            object[] atts = method.GetCustomAttributes(typeof(CriticalityAttribute), false);

            if (atts.Length > 0)
            {
                CriticalityAttribute att = (CriticalityAttribute)atts[0];
                crit = att.Criticality;
            }

            return crit;
        }

        /// <summary>
        ///     Verifica se um método ou sua classe devem ter quaisquer exceções aí
        ///     ocorridas ignoradas.
        /// </summary>
        /// <param name="method">
        ///     Objeto <see cref="MethodInfo"/> que representa o método a 
        ///     ser verificado.
        /// </param>
        /// <returns>
        ///     Retorna <see langword="true"/> se o método ou sua classe devem ter
        ///     exceções ignoradas e <see langword="false"/> caso não devam.
        /// </returns>
        private static bool CheckSkipExceptions(MethodBase method)
        {
            return CheckAttributeIn<SkipExceptionsAttribute>(method);
        }

        /// <summary>
        ///     Verifica se o erro deve ser impedido de prosseguir no pipeline.
        /// </summary>
        /// <param name="method">
        ///     Objeto <see cref="MethodInfo"/> que representa o método a 
        ///     ser verificado.
        /// </param>
        /// <returns>
        ///     Retorna <see langword="true"/> se o método ou sua classe devem ter
        ///     exceções ignoradas e <see langword="false"/> caso não devam.
        /// </returns>
        private static bool CheckForErrorCleaning(MethodBase method)
        {
            return CheckAttributeIn<ClearExceptionsAttribute>(method);
        }

        /// <summary>
        ///     Verifica se um determinado atributo existe um método ou sua classe.
        /// </summary>
        /// <param name="method">
        ///     Objeto <see cref="MethodInfo"/> que representa o método a 
        ///     ser verificado.
        /// </param>
        /// <returns>
        ///     Retorna <see langword="true"/> se o método ou sua classe possuirem o
        ///     atributo e <see langword="false"/> caso não possuam.
        /// </returns>
        private static bool CheckAttributeIn<T>(MethodBase method)
        {
            bool exists = false;

            if (method.GetCustomAttributes(typeof(T), false).Length > 0 ||
                method.DeclaringType.GetCustomAttributes(typeof(T), false).Length > 0)
            {
                exists = true;
            }

            return exists;
        }

        #endregion

        #endregion

        #region Public

        /// <summary>
        ///     Trata um erro ocorrido na aplicação.
        /// </summary>
        /// <param name="ctx">
        ///     Contexto da requisição na qual o erro ocorreu.
        /// </param>
        public static void HandleError(HttpContext ctx)
        {
            //Obtém as configurações da aplicação.
            AlchemyConfigurationSection config = AlchemyConfigurationSection.GetInstance();

            //Obtém o erro ocorrido e o envia para análise.
            bool cleanErrors = ParseException(ctx.Server.GetLastError(), config);

            //Verifica se é para impedir o prosseguimento do erro na requisição.
            if (cleanErrors || config.AlwaysClearExceptions) ctx.Server.ClearError();
        }

        #endregion

        #endregion
    }
}
