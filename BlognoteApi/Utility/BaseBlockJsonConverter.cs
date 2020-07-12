using System;
using BlognoteApi.Models.Blocks;
using Newtonsoft.Json.Linq;

namespace BlognoteApi.Utility
{
    public class BaseBlockJsonConverter : JsonCreationConverter<BaseBlock>
    {
        protected override BaseBlock Create(Type objectType, JObject jObject)
        {
            if (jObject == null)
                throw new ArgumentNullException("jObject");

            JToken typeToken = jObject[nameof(BaseBlock.Type)];
            string type = typeToken.Value<string>();
            if (string.IsNullOrEmpty(type))
                return null;

            return type switch
            {
                "text" => new TextBlock(),
                "image" => new ImageBlock(),
                "quote" => new QuoteBlock(),
                _ => null,
            };
        }
    }
}
