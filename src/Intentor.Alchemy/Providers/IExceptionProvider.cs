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

namespace Intentor.Alchemy.Providers
{
    /// <summary>
    ///     Define contrato para criação de provedores de
    ///     log de informações adicionais sobre exceções.
    /// </summary>
    internal interface IExceptionLogProvider
    {
        /// <summary>
        ///     Adiciona um log.
        /// </summary>
        /// <param name="log">
        ///     Objeto <see cref="LogData"/> a ser armazenado.
        /// </param>
        void AddLog(LogData log);

        /// <summary>
        ///     Obtém os logs armazenados.
        /// </summary>
        /// <returns>
        ///     Retorna uma lista dos objetos <see cref="LogData"/>
        ///     armazenados.
        /// </returns>
        List<LogData> GetLogs();

        /// <summary>
        ///     Limpa a lista de logs armazenados.
        /// </summary>
        void Clean();
    }
}
