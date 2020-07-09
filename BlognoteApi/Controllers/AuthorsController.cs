using System;
using System.Collections.Generic;
using BlognoteApi.Models;
using BlognoteApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlognoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService authorService;

        public AuthorsController(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public ActionResult<List<Author>> Get() => authorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAuthor")]
        public ActionResult<Author> Get(string id)
        {
            Author author = authorService.Get(id);
            if (author == null)
                return NotFound();

            return author;
        }

        [HttpPost]
        public ActionResult<Author> Create(Author author)
        {
            authorService.Create(author);
            return CreatedAtRoute("GetAuthor", new { id = author.Id.ToString() }, author);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Author authorIn)
        {
            Author author = authorService.Get(id);
            if (author == null)
                return NotFound();

            authorService.Update(id, authorIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            Author author = authorService.Get(id);
            if (author == null)
                return NotFound();

            authorService.Remove(author.Id);
            return NoContent();
        }
    }
}
