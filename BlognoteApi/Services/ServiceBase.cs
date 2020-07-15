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

        protected IMongoDatabase Database
        {
            get;
        }

        public ServiceBase(IBlognoteDatabaseSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            Database = client.GetDatabase(settings.DatabaseName);
            Entities = Database.GetCollection<TBase>(collectionName);
        }

        public List<TBase> Get()
        {
            List<TBase> entities = Entities.Find(entity => true).ToList();
            foreach (TBase entity in entities)
                this.MapEntityProperties(entity);
            return entities;
        }

        public TBase Get(string id)
        {
            TBase entity = Entities.Find(entity => entity.Id == id).FirstOrDefault();
            this.MapEntityProperties(entity);
            return entity;
        }

        public TBase Create(TBase entity)
        {
            Entities.InsertOne(entity);
            return entity;
        }

        public void Update(TBase entityToUpdate) =>
            Entities.ReplaceOne(entity => entity.Id == entityToUpdate.Id, entityToUpdate);

        protected virtual void MapEntityProperties(TBase entity)
        {
        }
    }
}
