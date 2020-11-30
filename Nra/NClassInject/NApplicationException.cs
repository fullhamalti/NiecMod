using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace NiecMod.Nra
{
    public class NApplicationException : Exception
    {
        private const int Result = -2146232832;

        public NApplicationException()
            : base("An application exception has occurred.")
        {
            if (NSystemException.__IListEx != null)
                NSystemException.__IListEx.Add(this);
            base.HResult = Result;
        }

        public NApplicationException(string message)
            : base(message)
        {
            if (NSystemException.__IListEx != null)
                NSystemException.__IListEx.Add(this);
            base.HResult = Result;
        }

        public NApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HResult = Result;
        }

        protected NApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
