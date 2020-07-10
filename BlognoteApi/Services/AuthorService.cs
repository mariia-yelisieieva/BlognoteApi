using System;
using BlognoteApi.Models;
using MongoDB.Driver;

namespace BlognoteApi.Services
{
    public class AuthorService : ServiceBase<Author>
    {
        public AuthorService(IBlognoteDatabaseSettings settings)
            : base(settings, settings.AuthorsCollectionName)
        {
        }

        public Author Create(Author author)
        {
            Entities.InsertOne(author);
            return author;
        }

        public void Update(string id, Author authorIn) =>
            Entities.ReplaceOne(author => author.Id == id, authorIn);

        public void Remove(Author authorIn) =>
            Entities.DeleteOne(author => author.Id == authorIn.Id);

        public void Remove(string id) =>
            Entities.DeleteOne(author => author.Id == id);
    }
}
