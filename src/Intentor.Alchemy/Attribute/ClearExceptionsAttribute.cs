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
    ///     Identifica que uma classe ou método deve ter os erros
    ///     sempre impedidos de prosseguir.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | 
        AttributeTargets.Method, 
        AllowMultiple = false)]
    public sealed class ClearExceptionsAttribute :
        System.Attribute
    {
        #region Construtor

        /// <summary>
        ///     Construtor da classe.
        /// </summary>
        public ClearExceptionsAttribute()
        {
        }

        #endregion
    }
}
