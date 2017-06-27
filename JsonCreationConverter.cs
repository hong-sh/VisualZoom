using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoyeoZoom
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType"> type of object expected </param>
        /// <param name="jObject"> contents of JSON object that will be deserialized </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            //JsonReader jObjectReader = jObject.CreateReader();
            //jObjectReader.Culture = reader.Culture;
            //jObjectReader.DateParseHandling = reader.DateParseHandling;
            //jObjectReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            //jObjectReader.FloatParseHandling = reader.FloatParseHandling;

            //// Populate the object properties
            //serializer.Populate(jObjectReader, target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
