/****************************************
Intentor.Alchemy
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Collections;
using System.Configuration;
using System.Xml;

namespace Intentor.Alchemy
{
    /// <summary>
    ///     Grupo de seção de configuração do componente
    ///     ExceptionHandling.
    /// </summary>
    public class AlchemyConfigurationSection
        : ConfigurationSection
    {
        /// <summary>
        ///     Nome da aplicação na qual o gerenciamento de erros está 
        ///     sendo executado.
        /// </summary>
        [ConfigurationProperty("applicationName", IsRequired = true)]
        public string ApplicationName
        {
            get
            {
                return this["applicationName"].ToString();
            }
            set
            {
                this["applicationName"] = value;
            }
        }

        /// <summary>
        ///     Versão da aplicação na qual o gerenciamento de erros
        ///     está sendo executado.
        /// </summary>
        [ConfigurationProperty("applicationVersion", IsRequired = true)]
        public string ApplicationVersion
        {
            get
            {
                return this["applicationVersion"].ToString();
            }
            set
            {
                this["applicationVersion"] = value;
            }
        }

        /// <summary>
        ///     Identifica se se deve impedir que os erros prossigam no pipeline do
        ///     ASP.Net após capturados.
        /// </summary>
        [ConfigurationProperty("alwaysClearExceptions", DefaultValue = false, IsRequired = false)]
        public bool AlwaysClearExceptions
        {
            get
            {
                return (bool)this["alwaysClearExceptions"];
            }
            set
            {
                this["alwaysClearExceptions"] = value;
            }
        }

        /// <summary>
        ///     Provedor utilizado para gerenciamento de erros.
        /// </summary>
        [ConfigurationProperty("provider", IsRequired = true)]
        public string ProviderName
        {
            get
            {
                return this["provider"].ToString();
            }
            set
            {
                this["provider"] = value;
            }
        }

        /// <summary>
        ///     Endereço do web service para o qual os erros serão enviados.
        /// </summary>
        [ConfigurationProperty("webServiceAddress", IsRequired = true)]
        public string WebServiceAddress
        {
            get
            {
                return this["webServiceAddress"].ToString();
            }
            set
            {
                this["webServiceAddress"] = value;
            }
        }        

        /// <summary>
        ///     Cria uma instância do objeto.
        /// </summary>
        /// <returns>
        ///     Retorna uma instância do objeto.
        /// </returns>
        public static AlchemyConfigurationSection GetInstance()
        {
            return (AlchemyConfigurationSection)System.Configuration.ConfigurationManager.GetSection(
                "intentor/alchemy");
        }
    }
}
