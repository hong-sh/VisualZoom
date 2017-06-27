using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoyeoZoom
{
    public class C_ARRAY : C_VARIABLE
    {
        public override string Name { get; set; }
        public override string Address { get; set; }
        public List<C_DATA> Values { get; set; }

        public C_ARRAY(string name, string addr, List<C_DATA> values)
        {
            Name = name;
            Address = addr;
            Values = values;
        }
    }
}
