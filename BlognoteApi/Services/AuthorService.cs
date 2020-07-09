using System;
using System.Collections.Generic;
using System.Linq;
using BlognoteApi.Models;
using MongoDB.Driver;

namespace BlognoteApi.Services
{
    public class AuthorService
    {
        private readonly IMongoCollection<Author> authors;

        public AuthorService(IBlognoteDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

        public List<Author> Get() =>
            authors.Find(author => true).ToList();

        public Author Get(string id) =>
            authors.Find(author => author.Id == id).FirstOrDefault();

        public Author Create(Author author)
        {
            authors.InsertOne(author);
            return author;
        }

        public void Update(string id, Author authorIn) =>
            authors.ReplaceOne(author => author.Id == id, authorIn);

        public void Remove(Author authorIn) =>
            authors.DeleteOne(author => author.Id == authorIn.Id);

        public void Remove(string id) =>
            authors.DeleteOne(author => author.Id == id);
    }
}
