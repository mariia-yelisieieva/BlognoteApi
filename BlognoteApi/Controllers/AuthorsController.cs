using System;
using BlognoteApi.Models;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BlognoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : EntityControllerBase<Author, AuthorService>
    {
        public AuthorsController(AuthorService authorService, JsonSerializer serializer) 
            : base(authorService, serializer)
        {
        }

        [HttpPost]
        public ActionResult<Author> Create(Author author)
        {
            EntityService.Create(author);
            return CreatedAtRoute("GetAuthor", new { id = author.Id.ToString() }, author);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Author authorIn)
        {
            Author author = EntityService.Get(id);
            if (author == null)
                return NotFound();

            EntityService.Update(id, authorIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            Author author = EntityService.Get(id);
            if (author == null)
                return NotFound();

            EntityService.Remove(author.Id);
            return NoContent();
        }
    }
}
