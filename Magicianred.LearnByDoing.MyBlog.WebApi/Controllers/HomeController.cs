using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Magicianred.LearnByDoing.MyBlog.WebApi.Controllers
{
    /// <summary>
    /// Handle Posts of blog
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostsService _postsService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postsService"></param>
        /// <param name="logger"></param>
        public HomeController(IPostsService postsService, ILogger<HomeController> logger)
        {
            _postsService = postsService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve all Posts
        /// GET: api/<HomeController>
        /// </summary>
        /// <returns>list of Posts</returns>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            var posts = _postsService.GetAll();
            return posts;
        }

        /// <summary>
        /// Retrieve the post with the id
        /// GET api/<HomeController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the post with requested id</returns>
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            var post = _postsService.GetById(id);
            return post;
        }
    }
}
