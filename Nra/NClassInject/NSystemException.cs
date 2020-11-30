using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace NiecMod.Nra
{
    public class NSystemException : Exception
    {
        private const int Result = -2146233087;

        public static List<Exception> __IListEx = new List<Exception>(5000);

        public NSystemException()
            : base("A system exception has occurred.")
        {
            if (__IListEx != null)
                __IListEx.Add(this);
            base.HResult = Result;
        }

        public NSystemException(string message)
            : base(message)
        {
            if (__IListEx != null)
                __IListEx.Add(this);
            base.HResult = Result;
        }

        protected NSystemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public NSystemException(string message, Exception innerException)
            : base(message, innerException)
        {
            if (__IListEx != null)
                __IListEx.Add(this);
            base.HResult = Result;
        }
    }
}
