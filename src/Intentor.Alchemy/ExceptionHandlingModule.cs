/****************************************
Intentor.Alchemy
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Web;

namespace Intentor.Alchemy
{
    /// <summary>
    ///     Módulo para captura e catalogação automatizado de erros.
    /// </summary>
    public class ExceptionHandlingModule :
        IHttpModule
    {
        /// <summary>
        ///     Inicializa o módulo.
        /// </summary>
        /// <param name="context">
        ///     Contexto da aplicação.
        /// </param>
        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(Error);
        }

        /// <summary>
        ///     Handler para captura de erros no nível da aplicação.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Error(object sender, EventArgs e)
        {
            ExceptionHandlingHelper.HandleError(HttpContext.Current);           
        }

        /// <summary>
        ///     Descarte do módulo.
        /// </summary>
        public void Dispose() { }
    }
}
