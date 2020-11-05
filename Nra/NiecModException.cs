/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 11/10/2018
 * Time: 8:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace NiecMod.Nra
{
	/// <summary>
	/// Description of NiecModException.
	/// </summary>
	public class NiecModException : Exception, ISerializable
	{
        // i know x32dbg 
        internal bool No_EA_Collect_Exception_ToString = false;//{ get; internal set; }
        internal bool ta = false;

        public NiecModException()
            : base("") // base(Locale.GetText("Invalid format."))
        {}

        public override System.Collections.IDictionary Data
        {
            get
            {
                if (ta) { 
                    //ta = false; 
                    return null; 
                }
                return base.Data;
            }
        }

        public override string Source
        {
            get
            {
                if (No_EA_Collect_Exception_ToString)
                    return "";
                return base.Source;
            }
            set
            {
                base.Source = value ?? "";
            }
        }
        public override string StackTrace
        {
            get
            {
                if (No_EA_Collect_Exception_ToString)
                    return "";
                return base.StackTrace;
            }
        }
        public override string ToString()
        {
            if (No_EA_Collect_Exception_ToString) 
                return "";
            return base.ToString();
        }

	 	public NiecModException(string message) : base(message) {}

		public NiecModException(string message, Exception innerException) : base(message, innerException) {}

		// This constructor is needed for serialization.
		protected NiecModException(SerializationInfo info, StreamingContext context) : base(info, context) {}
	}
    /// <summary>
    /// Description of NMAntiSpyException.
    /// </summary>
    public class NMAntiSpyException : Exception, ISerializable
    {
        // i know x32dbg 
        internal bool No_EA_Collect_Exception_ToString = false;//{ get; internal set; }
        internal bool ta = false;

        public NMAntiSpyException()
            : base("") // base(Locale.GetText("Invalid format."))
        { }

        public override System.Collections.IDictionary Data
        {
            get
            {
                if (ta)
                {
                    //ta = false; 
                    return null;
                }
                return base.Data;
            }
        }

        public override string Source
        {
            get
            {
                if (No_EA_Collect_Exception_ToString)
                    return "";
                return base.Source;
            }
            set
            {
                base.Source = value ?? "";
            }
        }
        public override string StackTrace
        {
            get
            {
                if (No_EA_Collect_Exception_ToString)
                    return "";
                return base.StackTrace;
            }
        }
        public override string ToString()
        {
            if (No_EA_Collect_Exception_ToString)
                return "";
            return base.ToString();
        }

        public NMAntiSpyException(string message) : base(message) { }

        public NMAntiSpyException(string message, Exception innerException) : base(message, innerException) { }

        // This constructor is needed for serialization.
        protected NMAntiSpyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}