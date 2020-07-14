using System;
using BlognoteApi.Models;
using Newtonsoft.Json.Linq;

namespace BlognoteApi.Utility
{
    public class EntityBaseJsonConverter : JsonCreationConverter<EntityBase>
    {
        protected override EntityBase Create(Type objectType, JObject jObject)
        {
            if (jObject == null)
                throw new ArgumentNullException("jObject");

            if (jObject.ContainsKey(nameof(Article.Annotation)))
                return new Article();
            else
                return new Author();
        }
    }
}
