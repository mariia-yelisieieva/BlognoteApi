using System;
using BlognoteApi.Models;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BlognoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : EntityControllerBase<Article, ArticleService>
    {
        public ArticlesController(ArticleService articleService, JsonSerializer serializer) 
            : base(articleService, serializer)
        {
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            EntityService.Create(article);
            return CreatedAtRoute("GetArticle", new { id = article.Id.ToString() }, article);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Article articleIn)
        {
            Article article = EntityService.Get(id);
            if (article == null)
                return NotFound();

            EntityService.Update(id, articleIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            Article article = EntityService.Get(id);
            if (article == null)
                return NotFound();

            EntityService.Remove(article.Id);
            return NoContent();
        }
    }
}
