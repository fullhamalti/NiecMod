using System;
using System.Collections.Generic;
using System.Text;

namespace NiecMod.Nra
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class CInvoteAttribute : Attribute
    {
        public string Comment;


        public CInvoteAttribute()
        { }

        public CInvoteAttribute(string comment)
        { Comment = comment; }
    }
}
