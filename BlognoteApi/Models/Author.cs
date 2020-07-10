using System;

namespace BlognoteApi.Models
{
    public class Author : EntityBase
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
