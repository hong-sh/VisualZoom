using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BoyeoZoom
{
    public class Visual
    {
        public string Code { get; set; }
        public List<Trace> Trace { get; set; }
        public string Time { get; set; }
        public long MemUsage { get; set; }

        public bool IsError()
        {
            return Trace[0].isError;
        }

        public string getAllStdout()
        {
            return Trace[Trace.Count - 1].Stdout;
        }

        public string getAllErrors()
        {
            string result = "";
            foreach (Trace trace in Trace)
            {
                result += trace.Exception_msg;
                result += Environment.NewLine;
            }
            return result;
        }

        public int getErrorLine()
        {
            return Trace[0].Line;
        }
    }

    class VisualConverter : JsonCreationConverter<Visual>
    {
        protected override Visual Create(Type objectType, JObject jObject)
        {
            Visual visual = new Visual();
            visual.Code = (string)jObject["code"];

            List<Trace> list = new List<Trace>();
            JArray ja = (JArray)jObject["trace"];
            foreach(JObject job in ja)
            {
                Trace stuff = JsonConvert.DeserializeObject<Trace>(job.ToString(), new TraceConverter());
                list.Add(stuff);
            }
            visual.Trace = list;

            visual.Time = (string)jObject["time"];
            visual.MemUsage = (long)jObject["memory"];

            return visual;
        }
    }
}
