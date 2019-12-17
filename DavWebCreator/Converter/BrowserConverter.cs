//using Browsers.Models.BrowserModels;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DavWebCreator.Server.Converter
//{
//    public class BrowserConverter : JsonConverter
//    {
//        public override bool CanRead => true;
//        public override bool CanWrite => false;
//        public override bool CanConvert(Type objectType)
//        {
//            return objectType == typeof(BrowserType);
//        }

//        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//        {
//            //// Variables.
//            //var fields = new List();
//            //var jsonArray = JArray.Load(reader);


//            //// Deserialize each form field.
//            //foreach (var item in jsonArray)
//            //{
//            //    // Create a form field instance by the field type ID.
//            //    var jsonObject = item as JObject;
//            //    var strTypeId = jsonObject["TypeId"].Value();
//            //    var typeId = Guid.Parse(strTypeId);
//            //    var instance = InstantiateFieldByTypeId(typeId);


//            //    // Populate the form field instance.
//            //    serializer.Populate(jsonObject.CreateReader(), instance);
//            //    fields.Add(instance);

//            }

//            // Return array of form fields.
//            return fields.ToArray();
//        }

//        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}