/****************************************
Intentor.Yamapper
*****************************************
Copyright © 2009 Intentor
Contact: intentor@ymail.com
****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Intentor.Yamapper
{
    [Serializable]
    public sealed class DataNotFoundException :
        System.Exception
    {
        public DataNotFoundException()
            :
            this(null) { }

        public DataNotFoundException(string message)
            :
            this(message, null) { }

        public DataNotFoundException(string message, Exception innerException)
            :
            base(message ?? "Registro não encontrado.", innerException) { }

        private DataNotFoundException(SerializationInfo info, StreamingContext context)
            :
            base(info, context) { }
    }
}
