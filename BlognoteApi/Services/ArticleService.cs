using System;
using System.Linq;
using BlognoteApi.Models;
using MongoDB.Driver;

namespace BlognoteApi.Services
{
    public class ArticleService : ServiceBase<Article>
    {
        private readonly IMongoCollection<Author> authors;

        public ArticleService(IBlognoteDatabaseSettings settings) : base(settings, settings.ArticlesCollectionName)
        {
            authors = Database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

        public void Remove(Article articleIn) =>
            Entities.DeleteOne(article => article.Id == articleIn.Id);

        public void Remove(string id) =>
            Entities.DeleteOne(article => article.Id == id);

        protected override void MapEntityProperties(Article article)
        {
            if (article == null)
                return;
            article.Author = this.authors.Find(author => author.Id == article.AuthorId).FirstOrDefault();
        }
    }
}
