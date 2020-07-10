using System;
using System.Collections.Generic;
using BlognoteApi.Models.Blocks;
using MongoDB.Bson.Serialization.Attributes;

namespace BlognoteApi.Models
{
    [BsonIgnoreExtraElements]
    public class Article : EntityBase
    {
        public string AuthorId { get; set; }

        public string Name { get; set; }

        public string Annotation { get; set; }

        public DateTime CreationDate{ get; set; }

        public List<BaseBlock> Blocks { get; set; }

        public Author Author { get; internal set; }
    }
}
