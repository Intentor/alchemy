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
    ///     Identifica a criticidade da ocorrência de erros
    ///     em um determinado método.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CriticalityAttribute :
        System.Attribute
    {
        #region Construtor

        /// <summary>
        ///     Construtor da classe.
        /// </summary>
        /// <param name="crit">
        ///     Criticidade do método.
        /// </param>
        public CriticalityAttribute(MethodCriticality crit)
        {
            _crit = crit;
        }

        #endregion

        #region Campos

        private MethodCriticality _crit;

        #endregion

        #region Propriedades

        /// <summary>
        ///     Criticidade do método.
        /// </summary>
        public MethodCriticality Criticality
        {
            get { return _crit; }
            set { _crit = value; }
        }

        #endregion
    }
}
