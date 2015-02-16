/****************************************
Intentor.Alchemy
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Collections.Generic;
using System.Web;
using Intentor.Utilities;

namespace Intentor.Alchemy.Providers
{
    /// <summary>
    ///     Provedor de armazenamento de logs para páginas web.
    /// </summary>
    /// <remarks>
    ///     Neste provedor, todos os logs são armazenados no contexto
    ///     da requisição HTTP atual.
    /// </remarks>
    internal class WebLogProvider :
        IExceptionLogProvider
    {
        private const string contextItemName = "ExceptionHandlingLogs";

        #region IExceptionLogProvider Members

        /// <summary>
        ///     Adiciona um item de log.
        /// </summary>
        /// <param name="log">
        ///     Item de log a ser adicionado.
        /// </param>
        public void AddLog(LogData log)
        {
            HttpContext current = HttpContext.Current;

            List<LogData> list;

            if (current.Items[contextItemName].IsNullOrDbNull())
            {
                list = new List<LogData>();
                current.Items[contextItemName] = list;
            }   
            else
            {
                list = (List<LogData>)current.Items[contextItemName];
            }

            list.Add(log);
        }

        /// <summary>
        ///     Obtém uma lista contendo todos os logs.
        /// </summary>
        /// <returns>
        ///     Retorna uma lista de objetos <see cref="LogData"/>.
        /// </returns>
        public List<LogData> GetLogs()
        {
            HttpContext current = HttpContext.Current;
            List<LogData> list = new List<LogData>();

            if (!current.Items[contextItemName].IsNullOrDbNull())
            {
                list = (List<LogData>)current.Items[contextItemName];
            }

            return list;
        }

        /// <summary>
        ///     Limpa todos os logs da lista cuja propriedade
        ///     "AlwaysKeepStored" seja <see langword="false"/>
        /// </summary>
        public void Clean()
        {
            HttpContext current = HttpContext.Current;

            if (!current.Items[contextItemName].IsNullOrDbNull())
            {
                List<LogData> oldList = (List<LogData>)current.Items[contextItemName];
                List<LogData> newList = new List<LogData>();

                foreach (LogData log in oldList)
                {
                    if (log.AlwaysKeepStored)
                    {
                        newList.Add(log);
                    }
                }

                oldList.Clear();
                current.Items[contextItemName] = newList;
            }
        }

        #endregion
    }
}
