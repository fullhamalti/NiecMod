using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace NiecMod.Nra
{
    public class NNullReferenceException : SystemException
    {
        private new const int Result = -2147467261;

        public NNullReferenceException()
            : base("Object reference not set to an instance of an object.")
        {
            base.HResult = Result;
        }

        public NNullReferenceException(string message)
            : base(message)
        {
            base.HResult = Result;
        }

        public NNullReferenceException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HResult = Result;
        }

        protected NNullReferenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
