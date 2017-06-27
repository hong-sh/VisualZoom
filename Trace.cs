using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BoyeoZoom
{
    public class Trace
    {
        public string Event { get; set; }
        public string Func_name { get; set; }
        public List<C_VARIABLE> Globals { get; set; }
        public List<C_VARIABLE> Heap { get; set; }
        public int Line { get; set; }
        public List<Stack_to_render> Stack_to_render { get; set; }
        public string Stdout { get; set; }

        public Boolean isError { get; set; }
        public string Exception_msg { get; set; }

        public List<List<C_VARIABLE>> getLocals()
        {
            List<List<C_VARIABLE>> list = new List<List<C_VARIABLE>>();

            foreach (var stack in Stack_to_render)
            {
                list.Add(stack.Encoded_locals);
            }

            return list;
        }

        public List<string> getFuncs()
        {
            List<string> list = new List<string>();

            foreach(var stack in Stack_to_render)
            {
                list.Add(stack.Func_name);
            }

            return list;
        }
    }

    class TraceConverter : JsonCreationConverter<Trace>
    {
        protected override Trace Create(Type objectType, JObject jObject)
        {

            Trace trace = new Trace();

            trace.Event = (string)jObject["event"];
            trace.Line = (int)jObject["line"];

            if (trace.Event == "uncaught_exception")
            {
                trace.Exception_msg = (string)jObject["exception_msg"];
                trace.isError = true;
            }
            else
            {
                trace.isError = false;
                trace.Func_name = (string)jObject["func_name"];

                List<string> ordered = VarsFunc.getOrdered((JArray)jObject["ordered_globals"]);
                trace.Globals = VarsFunc.getVars((JObject)jObject["globals"], ordered);
                trace.Heap = VarsFunc.getVars((JObject)jObject["heap"]);
                trace.Stack_to_render = getStack((JArray)jObject["stack_to_render"]);
                trace.Stdout = (string)jObject["stdout"];
            }
            

            return trace;
        }

        private List<Stack_to_render> getStack(JArray ja)
        {
            List<Stack_to_render> list = new List<Stack_to_render>();
            foreach (JObject job in ja)
            {
                Stack_to_render stack = JsonConvert.DeserializeObject<Stack_to_render>(job.ToString(), new StackConverter());
                list.Add(stack);
            }

            return list;
        }
    }
}