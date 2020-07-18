using System;
using System.Collections.Generic;
using BlognoteApi.Models;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [Authorize(Policy = "Consumer")]
        [HttpPost("create")]
        public ActionResult<TEntity> Create(TEntity entity)
        {
            entity = EntityService.Create(entity);
            return Ok(JsonConvert.SerializeObject(entity.Id));
        }

        [Authorize(Policy = "Consumer")]
        [HttpPut("update")]
        public IActionResult Update(TEntity entity)
        {
            TEntity foundEntity = EntityService.Get(entity.Id);
            if (foundEntity == null)
                return NotFound();

            EntityService.Update(entity);
            return NoContent();
        }
    }
}
