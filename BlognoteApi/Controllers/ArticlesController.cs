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

        [Authorize(Policy = "Consumer")]
        [HttpDelete("remove/{id}")]
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
