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
        private readonly ICategoriesService _categoriesService;
        private readonly ITagsService _tagsService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postsService"></param>
        /// <param name="categoriesService"></param>
        /// <param name="tagsService"></param>
        /// <param name="logger"></param>
        public HomeController(IPostsService postsService, 
                                ICategoriesService categoriesService,
                                ITagsService tagsService,
                                ILogger<HomeController> logger)
        {
            _postsService = postsService;
            _categoriesService = categoriesService;
            _tagsService = tagsService;
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
        /// Retrieve all Categories
        /// GET: <HomeController>\Categories
        /// </summary>
        /// <returns>list of Categories</returns>
        public IActionResult Categories()
        {
            var categories = _categoriesService.GetAll();
            return View(categories);
        }

        /// <summary>
        /// Retrieve the category with the id
        /// GET <HomeController>/Category/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the category with requested id</returns>
        public IActionResult Category(int id)
        {
            var category = _categoriesService.GetById(id);
            return View(category);
        }

        /// <summary>
        /// Retrieve all Tags
        /// GET: <HomeController>\Tags
        /// </summary>
        /// <returns>list of Tags</returns>
        public IActionResult Tags()
        {
            var tags = _tagsService.GetAll();
            return View(tags);
        }

        /// <summary>
        /// Retrieve the tag with the id
        /// GET <HomeController>/Tag/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the tag with requested id</returns>
        public IActionResult Tag(int id)
        {
            var tag = _tagsService.GetById(id);
            return View(tag);
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
