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
        public AuthorsController(AuthorService authorService, CustomJsonSerializer serializer) 
            : base(authorService, serializer)
        {
        }
    }
}
