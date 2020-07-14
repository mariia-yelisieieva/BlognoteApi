using System;
using BlognoteApi.Models;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlognoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : EntityControllerBase<Author, AuthorService>
    {
        public AuthorsController(AuthorService authorService, CustomJsonSerializer serializer) 
            : base(authorService, serializer)
        {
        }

        //[Authorize(Policy = "Consumer")]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Author authorIn)
        {
            Author author = EntityService.Get(id);
            if (author == null)
                return NotFound();

            EntityService.Update(id, authorIn);
            return NoContent();
        }
    }
}
