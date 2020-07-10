using System;
using Newtonsoft.Json;

namespace BlognoteApi.Utility
{
    public class JsonSerializer
    {
        public string SerializeWithDerivedClasses(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}
