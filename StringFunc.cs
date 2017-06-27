using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoyeoZoom
{
    public class StringFunc
    {
        public static string toBeauty(string txt, Boolean isChar)
        {
            string result = txt;

            if (txt == "" || txt == "<UNINITIALIZED>") result = "?";
            if (txt == "\t")
            {
                result = "t";
                result = @"\" + result;
            }
            if (txt == "\n")
            {
                result = "n";
                result = @"\" + result;
            }



            if (isChar)
            {
                result = "'" + result + "'";
            }

            return result;
        }
    }
}
