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
    ///     Representa uma informação de log.
    /// </summary>
    public struct LogData
    {
        #region Construtor

        /// <summary>
        ///     Representa uma informação de log.
        /// </summary>
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
        public LogData(string methodName
            , string identifier
            , string description
            , bool isWarning
            , bool alwaysKeepStored)
        {
            Check.Require(methodName.Length <= 200);
            Check.Require(identifier.Length <= 100);
            Check.Require(description.Length <= 500);

            _methodName = methodName;
            _identifier = identifier;
            _description = description;
            _isWarning = isWarning;
            _alwaysKeepStored = alwaysKeepStored;
        }

        #endregion

        #region Campos

        private string _methodName;
        private string _identifier;
        private string _description;
        private bool _isWarning;
        private bool _alwaysKeepStored;

        #endregion

        #region Propriedades

        /// <summary>
        ///     Nome do método o qual solicitou a escrita do log.
        /// </summary>
        public string MethodName
        {
            get { return _methodName; }
            set 
            {
                Check.Require(value.Length <= 200);
                _methodName = value; 
            }
        }

        /// <summary>
        ///     Identificador do log.
        /// </summary>
        public string Identifier
        {
            get { return _identifier; }
            set
            {
                Check.Require(value.Length <= 100);
                _identifier = value;
            }
        }

        /// <summary>
        ///     Descrição do log.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                Check.Require(value.Length <= 500);
                _description = value;
            }
        }

        /// <summary>
        ///     Indica se o log é de alerta. Caso não seja,
        ///     é considerado como log de aplicação.
        /// </summary>
        public bool IsWarning
        {
            get { return _isWarning; }
            set { _isWarning = value; }
        }

        /// <summary>
        ///     Identifica se é para se manter o log durante
        ///     uma ação de limpeza da lista de logs.
        /// </summary>
        public bool AlwaysKeepStored
        {
            get { return _alwaysKeepStored; }
            set { _alwaysKeepStored = value; }
        }

        #endregion

        #region Overrides

        /// <summary>
        ///     Compara o objeto atual com outro.
        /// </summary>
        /// <param name="obj">
        ///     Objeto a ser comparado.
        /// </param>
        /// <returns>
        ///     Valor booleano indicando resultado da comparação.
        /// </returns>
        public override bool Equals(object obj)
        {
            bool equals = false;

            if (obj is LogData)
            {
                LogData data = (LogData)obj;

                if (this.MethodName == data.MethodName &&
                    this.Identifier == data.Identifier &&
                    this.Description == data.Description &&
                    this.IsWarning == data.IsWarning &&
                    this.AlwaysKeepStored == data.AlwaysKeepStored)
                    equals = true;
            }


            return equals;
        }

        /// <summary>
        ///     Obtém o HashCode do log.
        /// </summary>
        /// <returns>   
        ///     HashCode do log.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        ///     Converte o log para string.
        /// </summary>
        /// <returns>
        ///     Mensagem de log.
        /// </returns>
        public override string ToString()
        {
            string text = String.Concat(
                        "[", this.MethodName, "] "
                        ,(IsWarning ? "[ALERTA] " : String.Empty));

            if (String.IsNullOrEmpty(this.Identifier))
            {
                text = String.Concat(text, this.Description);
            }
            else
            {
                text = String.Concat(text, this.Identifier, ": ", this.Description);                    
            }

            return text;
        }

        #endregion
    }
}
