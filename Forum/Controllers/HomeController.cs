using Forum.Core.Contracts;
using Forum.Extensions;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forum.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService service;

        public HomeController(ILogger<HomeController> logger,IPostService _service)
        {
            _logger = logger;
            service = _service;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(PostController.All), "Post");
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}