using System;
using System.Collections.Generic;
using System.Text;

namespace TRIALTEST.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayNameAttribute : Attribute
    {
        public string name { get; set; }
        public DisplayNameAttribute(string name)
        {
            this.name = name;
        }
    }
}
