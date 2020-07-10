using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BlognoteApi.Models.Blocks
{
    [BsonIgnoreExtraElements]
    public class ImageBlock : BaseBlock
    {
        public string ImageComment { get; set; }
    }
}
