using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlognoteApi.Models
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
