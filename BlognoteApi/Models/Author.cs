using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlognoteApi.Models
{
    public class Author : EntityBase
    {
        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
