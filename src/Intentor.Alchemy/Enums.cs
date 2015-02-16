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
    ///     Criticidade do método em relação à ocorrência
    ///     de erros.
    /// </summary>
    public enum MethodCriticality
    {
        /// <summary>
        ///     Criticidade não informada.
        /// </summary>
        NotInformed = 0,
        /// <summary>
        ///     Criticidade baixa.
        /// </summary>
        Low = 1,
        /// <summary>
        ///     Criticidade média.
        /// </summary>
        Medium = 2,
        /// <summary>
        ///     Criticidade alta.
        /// </summary>
        High = 3
    }
}
