using Browsers.Models.BrowserModels.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RAGE;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DavWebCreator.Clients.Converter
{
    public class BrowserConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IBrowserElement>) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);

            List<IBrowserElement> elements = array.ToObject<List<IBrowserElement>>();
            //List<BrowserElement> newElements = new List<BrowserElement>();

            //for (int i = 0; i < elements.Count; i++)
            //{
            //    Chat.Output(elements[i].Position.ToString() + " - ..");
            //    if(elements[i].Type == BrowserElementType.Title)
            //    {
            //       newElements.Add(elements[i] as BrowserTitle);
            //    }
            //}

            return elements;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
