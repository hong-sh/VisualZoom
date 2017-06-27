using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BoyeoZoom
{
    public class Stack_to_render
    {
        public List<C_VARIABLE> Encoded_locals { get; set; }
        public string Frame_id { get; set; }
        public string Func_name { get; set; }
        public bool Is_highlighted { get; set; }
        public bool Is_parent { get; set; }
        public bool Is_zombie { get; set; }
        //public List<string> Ordered_varnames { get; set; }
        //parent_frame_id_list
        public string Unique_hash { get; set; }
    }

    public class StackConverter : JsonCreationConverter<Stack_to_render>
    {
        protected override Stack_to_render Create(Type objectType, JObject jObject)
        {
            Stack_to_render stack = new Stack_to_render();

            List<string> ordered = VarsFunc.getOrdered((JArray)jObject["ordered_varnames"]);
            stack.Encoded_locals = VarsFunc.getVars((JObject) jObject["encoded_locals"], ordered);
            stack.Frame_id = (string)jObject["frame_id"];
            stack.Func_name = (string)jObject["func_name"];
            stack.Is_highlighted = (bool)jObject["is_highlighted"];
            stack.Is_parent = (bool)jObject["is_parent"];
            stack.Is_zombie = (bool)jObject["is_zombie"];
            //parent_frame_id_list
            stack.Unique_hash = (string)jObject["unique_hash"];


            return stack;
        }
    }
}