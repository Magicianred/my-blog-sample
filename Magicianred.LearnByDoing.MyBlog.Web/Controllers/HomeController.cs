using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Magicianred.LearnByDoing.MyBlog.Web.Models;
using Magicianred.LearnByDoing.MyBlog.BL.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;

namespace Magicianred.LearnByDoing.MyBlog.Web.Controllers
{
    /// <summary>
    /// Handle Posts of blog
    /// </summary>
    public class HomeController : Controller
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
        /// GET: <HomeController>
        /// </summary>
        /// <returns>list of Posts</returns>
        public IActionResult Index()
        {
            var posts = _postsService.GetAll();
            return View(posts);
        }

        /// <summary>
        /// Retrieve the post with the id
        /// GET <HomeController>/Post/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the post with requested id</returns>
        public IActionResult Post(int id)
        {
            var post = _postsService.GetById(id);
            return View(post);
        }

        /// <summary>
        /// Show about page
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Show contact page
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Show error in page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
