using System;
using BlognoteApi.Utility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BlognoteApi.Models
{
    [JsonConverter(typeof(EntityBaseJsonConverter))]
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
