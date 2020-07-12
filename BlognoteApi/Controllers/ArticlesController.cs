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
    public class ArticlesController : EntityControllerBase<Article, ArticleService>
    {
        public ArticlesController(ArticleService articleService, CustomJsonSerializer serializer) 
            : base(articleService, serializer)
        {
        }

        //[Authorize(Policy = "Consumer")]
        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            EntityService.Create(article);
            return CreatedAtRoute("GetArticle", new { id = article.Id.ToString() }, article);
        }

        //[Authorize(Policy = "Consumer")]
        [HttpPut("update")]
        public IActionResult Update(Article article)
        {
            Article foundArticle = EntityService.Get(article.Id);
            if (foundArticle == null)
                return NotFound();

            EntityService.Update(article);
            return NoContent();
        }

        //[Authorize(Policy = "Consumer")]
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
