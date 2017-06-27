using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoyeoZoom
{
    public class VarsFunc
    {
        public static List<C_VARIABLE> getVars(JObject jo, List<string> ordered)
        {
            List<C_VARIABLE> list = new List<C_VARIABLE>();

            foreach (string name in ordered)
            {
                JArray contents = (JArray)jo[name];
                string type = contents[0].ToString();
                if (type == "C_DATA")
                {
                    C_DATA cd = mkDATA(name, contents);
                    list.Add(cd);
                }
                else if (type == "C_ARRAY")
                {
                    List<C_DATA> values = new List<C_DATA>();
                    for (int i = 2; i < contents.Count; i++)
                    {
                        JArray idx = (JArray)contents[i];
                        values.Add(mkDATA((i - 2).ToString(), idx));
                    }
                    C_ARRAY ca = new C_ARRAY(name, contents[1].ToString(), values);
                    list.Add(ca);
                }
            }

            return list;
        }

        public static List<C_VARIABLE> getVars(JObject jo)
        {
            List<C_VARIABLE> list = new List<C_VARIABLE>();

            foreach (var item in jo)
            {
                string name = item.Key;
                JArray contents = (JArray)item.Value;
                string type = contents[0].ToString();
                if (type == "C_DATA")
                {
                    C_DATA cd = mkDATA(name, contents);
                    list.Add(cd);
                }
                else if (type == "C_ARRAY")
                {
                    List<C_DATA> values = new List<C_DATA>();
                    for (int i = 2; i < contents.Count; i++)
                    {
                        JArray idx = (JArray)contents[i];
                        values.Add(mkDATA((i - 2).ToString(), idx));
                    }
                    C_ARRAY ca = new C_ARRAY(name, contents[1].ToString(), values);
                    list.Add(ca);
                }
            }

            return list;
        }

        public static List<string> getOrdered(JArray ja)
        {
            List<string> og = new List<string>();
            foreach (string obj in ja)
            {
                og.Add(obj);
            }
            return og;
        }

        private static C_DATA mkDATA(string name, JArray content)
        {
            string addr = content[1].ToString();
            string type = content[2].ToString();
            string value = content[3].ToString();
            C_DATA cd = new C_DATA(name, addr, type, value);
            return cd;
        }
    }
}
