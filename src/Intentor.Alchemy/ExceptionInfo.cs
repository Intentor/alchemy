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
using Intentor.Utilities;

namespace Intentor.Alchemy
{
    /// <summary>
    ///     Representa informações sobre uma exceção.
    /// </summary>
    public class ExceptionInfo
    {
        #region Construtor

        /// <summary>
        ///     Construtor da classe.
        /// </summary>
        /// <param name="applicationName">
        ///     Nome da aplicação na qual a exceção foi gerado.
        /// </param>
        /// <param name="applicationVersion">
        ///     Versão da aplicação na qual a exceção foi gerado.
        /// </param>
        /// <param name="description">
        ///     Descrição da exceção.
        /// </param>
        public ExceptionInfo(string applicationName
            ,string applicationVersion
            ,string description)
        {
            _applicationName = applicationName;
            _applicationVersion = applicationVersion;
            _description = description;
        }

        #endregion

        #region Campos
        
        private short _criticality;
        private string _applicationName;
        private string _applicationVersion;
        private string _description;
        private string _source;
        private string _methodName;
        private string _stackTrace;
        private List<LogData> _logs;

        #endregion

        #region Propriedades

        /// <summary>
        ///     Criticidade da exceção.
        /// </summary>
        /// <remarks>
        ///     Criticidade "0" indica que não foi
        ///     informada uma criticidade.
        /// </remarks>
        public short Criticality
        {
            get { return _criticality; }
            set { _criticality = value; }
        }

        /// <summary>
        ///     Nome da aplicação na qual a exceção foi gerado.
        /// </summary>
        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        /// <summary>
        ///     Versão da aplicação na qual a exceção foi gerada.
        /// </summary>
        public string ApplicationVersion
        {
            get { return _applicationVersion; }
            set {
                Check.Require(value.Length <= 10); 
                _applicationVersion = value; 
            }
        }

        /// <summary>
        ///     Descrição da exceção.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set {
                if (value.Length <= 1500)
                {
                    value = value.Substring(0, 1500);
                }
                _description = value; 
            }
        }

        /// <summary>
        ///     Nome do assembly no qual a exceção ocorreu.
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { 
                if (value.Length <= 300)
                {
                    value = value.Substring(0, 300);
                }
                _source = value;
            }
        }

        /// <summary>
        ///     Nome do método no qual a exceção foi disparado.
        /// </summary>
        public string MethodName
        {
            get { return _methodName; }
            set
            {
                if (value.Length <= 200)
                {
                    value = value.Substring(0, 200);
                }
                _methodName = value;
            }
        }

        /// <summary>
        ///     Rastreamento de pilha da exceção.
        /// </summary>
        public string StackTrace
        {
            get { return _stackTrace; }
            set
            {
                if (value.Length <= 2000)
                {
                    value = value.Substring(0, 2000);
                }
                _stackTrace = value;
            }
        }

        /// <summary>
        ///     Informações adicionais da execução do método definidas
        ///     pelo programador.
        /// </summary>
        public List<LogData> Logs
        {
            get { return _logs; }
            set { _logs = value; }
        }

        /// <summary>
        ///     Informações adicionais da execução do método definidas
        ///     pelo programador.
        /// </summary>
        public List<LogData> AdditionalInformations
        {
            get {
                List<LogData> list = (List<LogData>)_logs.Where(IsWarning => IsWarning.Equals(false));

                return list;
            }
        }

        /// <summary>
        ///     Alertas adicionais da execução do método definidos
        ///     pelo programador.
        /// </summary>
        public List<LogData> AdditionalWarnings
        {
            get
            {
                List<LogData> list = (List<LogData>)_logs.Where(IsWarning => IsWarning.Equals(true));

                return list;
            }
        }

        #endregion
    }
}
