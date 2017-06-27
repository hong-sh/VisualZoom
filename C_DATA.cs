using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoyeoZoom
{
    public class C_DATA : C_VARIABLE
    {
        public override string Name { get; set; }
        public override string Address { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public C_DATA(string name, string addr, string type, string value)
        {
            Name = name;
            Address = addr;
            Type = type;
            Value = value;
        }
    }
}
