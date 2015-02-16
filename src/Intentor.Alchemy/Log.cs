/****************************************
Intentor.Alchemy
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Intentor.Alchemy.Providers;
using Intentor.Utilities;

namespace Intentor.Alchemy
{
    /// <summary>
    ///     Realiza log de erros.
    /// </summary>
    public static class Log
    {
        #region Campos

        private const string WriteRequireMessage = "Deve-se informar um texto para o log.";
        private const string WarnRequireMessage = "Deve-se informar um texto para o log de alerta.";

        #endregion

        #region Métodos

        #region Private

        /// <param name="methodName">
        ///     Nome do método o qual solicitou a escrita do log.
        /// </param>
        /// <param name="identifier">
        ///     Identificador do log.
        /// </param>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        /// <param name="isWarning">
        ///     Indica se o log é de alerta. Caso não seja,
        ///     é considerado como log de aplicação.
        /// </param>
        /// <param name="alwaysKeepStored">
        ///     Identifica se é para se manter o log durante
        ///     uma ação de limpeza da lista de logs.
        /// </param>
        private static void Addlog(string methodName
            ,string identifier
            ,string description
            ,bool isWarning
            ,bool alwaysKeepStored)
        {
            LogData log = new LogData(methodName
                , identifier
                , description
                , isWarning
                , alwaysKeepStored);

            ExceptionProviderFactory.GetProvider().AddLog(log);
        }

        #endregion

        #region Public

        #region Write

        /// <summary>
        ///     Armazena um log de aplicação.
        /// </summary>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        public static void Write(string description)
        {
            Check.Require(!String.IsNullOrEmpty(description), WriteRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , String.Empty
                , description
                , false
                , false);
        }

        /// <summary>
        ///     Armazena um log de aplicação.
        /// </summary>
        /// <param name="identifier">
        ///     Identificador do log.
        /// </param>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        public static void Write(string identifier
            , string description)
        {
            Check.Require(!String.IsNullOrEmpty(description), WriteRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , identifier
                , description
                , false
                , false);
        }

        /// <summary>
        ///     Armazena um log de aplicação.
        /// </summary>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        /// <param name="alwaysKeepStored">
        ///     Identifica se é para se manter o log durante
        ///     uma ação de limpeza da lista de logs.
        /// </param>
        public static void Write(string description
            , bool alwaysKeepStored)
        {
            Check.Require(!String.IsNullOrEmpty(description), WriteRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , String.Empty
                , description
                , false
                , alwaysKeepStored);
        }

        /// <summary>
        ///     Armazena um log de aplicação.
        /// </summary>
        /// <param name="identifier">
        ///     Identificador do log.
        /// </param>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        /// <param name="alwaysKeepStored">
        ///     Identifica se é para se manter o log durante
        ///     uma ação de limpeza da lista de logs.
        /// </param>
        public static void Write(string identifier
            ,string description
            ,bool alwaysKeepStored)
        {
            Check.Require(!String.IsNullOrEmpty(description), WriteRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , identifier
                , description
                , false
                , alwaysKeepStored);
        }

        #endregion

        #region Warn

        /// <summary>
        ///     Armazena um log de alerta.
        /// </summary>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        public static void Warn(string description)
        {
            Check.Require(!String.IsNullOrEmpty(description), WarnRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , String.Empty
                , description
                , false
                , false);
        }

        /// <summary>
        ///     Armazena um log de alerta.
        /// </summary>
        /// <param name="identifier">
        ///     Identificador do log.
        /// </param>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        public static void Warn(string identifier
            , string description)
        {
            Check.Require(!String.IsNullOrEmpty(description), WarnRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , identifier
                , description
                , false
                , false);
        }

        /// <summary>
        ///     Armazena um log de alerta.
        /// </summary>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        /// <param name="alwaysKeepStored">
        ///     Identifica se é para se manter o log durante
        ///     uma ação de limpeza da lista de logs.
        /// </param>
        public static void Warn(string description
            , bool alwaysKeepStored)
        {
            Check.Require(!String.IsNullOrEmpty(description), WarnRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , String.Empty
                , description
                , false
                , alwaysKeepStored);
        }

        /// <summary>
        ///     Armazena um log de alerta.
        /// </summary>
        /// <param name="identifier">
        ///     Identificador do log.
        /// </param>
        /// <param name="description">
        ///     Descrição do log.
        /// </param>
        /// <param name="alwaysKeepStored">
        ///     Identifica se é para se manter o log durante
        ///     uma ação de limpeza da lista de logs.
        /// </param>
        public static void Warn(string identifier
            , string description
            , bool alwaysKeepStored)
        {
            Check.Require(!String.IsNullOrEmpty(description), WarnRequireMessage);

            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Addlog(methodName
                , identifier
                , description
                , false
                , alwaysKeepStored);
        }

        #endregion

        /// <summary>
        ///     Obtém todos os logs criados.
        /// </summary>
        /// <returns>
        ///     Retorna uma lista de objetos <see cref="LogData"/>.
        /// </returns>
        public static List<LogData> GetLogs()
        {
            return ExceptionProviderFactory.GetProvider().GetLogs();
        }

        #endregion

        #endregion
    }
}
