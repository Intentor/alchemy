/****************************************
Intentor.Alchemy
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intentor.Alchemy
{
    /// <summary>
    ///     Métodos de apoio para envio de dados ao web service.
    /// </summary>
    internal class AnalysisServiceHelper :
        IDisposable
    {
        #region Construtor

        /// <summary>
        ///     Construtor da classe.
        /// </summary>
        /// <param name="webServiceAdreess">
        ///     Endereço do web service.
        /// </param>
        public AnalysisServiceHelper(string webServiceAdreess)
        {
            //Obtém e prepara a instância do web service.
            _webServiceAddress = webServiceAdreess;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        #region Campos

        /// <summary>
        ///     Endereço do web service.
        /// </summary>
        private string _webServiceAddress;

        #endregion

        #region Métodos

        /// <summary>
        ///     Envia uma lista de exceções para o webservice.
        /// </summary>
        /// <param name="exceptions">
        ///     Lista de exceções a serem enviadas.
        /// </param>
        public void SendExceptions(List<ExceptionInfo> exceptions)
        {
            throw new NotImplementedException();

            /*
            //TODO: Caso o WS não consiga receber as exceções, armazenar em pasta temporária.
            using (Intentor.Utilites.Analysis.Analysis ws = new Intentor.Utilites.Analysis.Analysis())
            {
                ws.Url = ExceptionHandlingSection.GetInstance().WebServiceAddress;

                foreach (ExceptionInfo info in exceptions)
                {
                    int idException = ws.SendException((short)info.Criticality
                        , info.ApplicationName
                        , info.ApplicationVersion
                        , info.Description
                        , info.Source
                        , info.MethodName
                        , info.StackTrace);

                    foreach (LogData log in info.Logs)
                    {
                        ws.SendAdditionalInfo(idException
                            , log.MethodName
                            , log.Identifier
                            , log.Description
                            , log.IsWarning);
                    }
                }
            }
            */
        }

        #endregion

       
    }
}
