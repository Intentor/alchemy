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
using System.Reflection;
using Intentor.Utilities;

namespace Intentor.Alchemy.Providers
{
    /// <summary>
    ///     Provê métodos para obtenção do correto provider
    ///     de escrita de logs de exceção.
    /// </summary>
    internal static class ExceptionProviderFactory
    {
        #region Construtor

        /// <summary>
        ///     Construtor da classe.
        /// </summary>
        static ExceptionProviderFactory()
        {
            ResolveProvider();
        }

        #endregion

        #region Campos

        /// <summary>
        ///     ProviderName para escrita e obtenção de logs.
        /// </summary>
        private static IExceptionLogProvider _logProvider;

        #endregion

        #region Métodos

        #region Private

        /// <summary>
        ///     Obtém o provider correto, conforme especificado pelo atributo 
        ///     "provider" no web.config.
        /// </summary>
        private static void ResolveProvider()
        {
            if (_logProvider.IsNullOrDbNull())
            {
                lock (typeof(ExceptionProviderFactory))
                {
                    string providerName = AlchemyConfigurationSection.GetInstance().ProviderName;
                    Type t = ReflexionHelper.GetTypeFromAssembly(providerName, "Intentor.Utilites");
                    _logProvider = (IExceptionLogProvider)Activator.CreateInstance(t);
                }
            }
        }

        #endregion

        #region Public

        /// <summary>
        ///     Obtém o provider para uso de log de informações adicionais de erro.
        /// </summary>
        /// <returns>
        ///     Retorna uma instância herdada da interface <see cref="IExceptionLogProvider"/>.
        /// </returns>
        public static IExceptionLogProvider GetProvider()
        {
            return _logProvider;
        }

        #endregion

        #endregion
    }
}
