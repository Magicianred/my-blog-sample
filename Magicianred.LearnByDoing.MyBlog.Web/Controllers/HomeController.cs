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

namespace Magicianred.LearnByDoing.MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostsService _postsService;

        public HomeController(IPostsService postsService, ILogger<HomeController> logger)
        {
            _postsService = postsService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var posts = _postsService.GetAll();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
