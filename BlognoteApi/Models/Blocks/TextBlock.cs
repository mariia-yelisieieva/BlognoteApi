using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BlognoteApi.Models.Blocks
{
    [BsonIgnoreExtraElements]
    public class TextBlock : BaseBlock
    {
        public string Name { get; set; }
    }
}
