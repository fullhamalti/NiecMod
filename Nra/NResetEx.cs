using System;
using System.Collections.Generic;
using System.Text;
using Sims3.SimIFace;
namespace NiecMod.Nra
{
    public class NResetEx : ResetException
    {
        public override string Message
        {
            get
            {
                return "";
            }
        }
        
        public override Exception GetBaseException()
        {
            inner_exception = null;
            return this;
        }

        public override string StackTrace
        {
            get
            {
                return "";
            }
        }
        public override string ToString()
        {
            return "";//"Sims3.SimIFace.ResetException: Exception of type Sims3.SimIFace.ResetException was thrown.";
        }
    }
}
