using Forum.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await postService.AllPostAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }   

        public IActionResult Index()
        {
            return View();
        }
    }
}
