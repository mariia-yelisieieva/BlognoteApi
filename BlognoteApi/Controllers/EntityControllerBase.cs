using System;
using System.Collections.Generic;
using BlognoteApi.Models;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BlognoteApi.Controllers
{
    public abstract class EntityControllerBase<TEntity, TEntityService> : ControllerBase
        where TEntity : EntityBase
        where TEntityService : ServiceBase<TEntity>
    {
        protected TEntityService EntityService
        {
            get;
        }
        protected CustomJsonSerializer Serializer
        {
            get;
        }

        public EntityControllerBase(TEntityService entityService, CustomJsonSerializer serializer)
        {
            this.EntityService = entityService;
            this.Serializer = serializer;
        }

        [HttpGet]
        public ActionResult<List<TEntity>> Get()
        {
            List<TEntity> entities = EntityService.Get();
            string serialized = Serializer.SerializeWithDerivedClasses(entities);
            return Ok(serialized);
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(string id)
        {
            TEntity entity = EntityService.Get(id);
            if (entity == null)
                return NotFound();

            string serialized = Serializer.SerializeWithDerivedClasses(entity);
            return Ok(serialized);
        }
    }
}
