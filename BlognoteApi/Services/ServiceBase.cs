using System;
using System.Collections.Generic;
using System.Linq;
using BlognoteApi.Models;
using MongoDB.Driver;

namespace BlognoteApi.Services
{
    public abstract class ServiceBase<TBase> where TBase : EntityBase
    {
        protected IMongoCollection<TBase> Entities
        {
            get;
        }

        public ServiceBase(IBlognoteDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            Entities = database.GetCollection<TBase>(settings.AuthorsCollectionName);
        }

        public List<TBase> Get()
        {
            List<TBase> entities = Entities.Find(author => true).ToList();
            foreach (TBase entity in entities)
                this.MapEntityProperties(entity);
            return entities;
        }

        public TBase Get(string id)
        {
            TBase entity = Entities.Find(author => author.Id == id).FirstOrDefault();
            this.MapEntityProperties(entity);
            return entity;
        }

        protected virtual void MapEntityProperties(TBase entity)
        {
        }
    }
}
