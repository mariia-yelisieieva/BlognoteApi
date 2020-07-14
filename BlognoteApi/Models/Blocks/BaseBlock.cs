using System;
using BlognoteApi.Utility;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BlognoteApi.Models.Blocks
{
    [BsonIgnoreExtraElements]
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(TextBlock), typeof(ImageBlock), typeof(QuoteBlock))]
    [JsonConverter(typeof(BaseBlockJsonConverter))]
    public abstract class BaseBlock
    {
        public int BlockId { get; set; }

        public int Order { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }
    }
}
