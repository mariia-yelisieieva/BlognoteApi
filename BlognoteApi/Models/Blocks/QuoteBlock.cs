using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BlognoteApi.Models.Blocks
{
    [BsonIgnoreExtraElements]
    public class QuoteBlock : BaseBlock
    {
        public string QuoteAuthor { get; set; }
    }
}
