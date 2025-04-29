using Forum.Core.Contracts;
using Forum.Core.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly IThreadService threadService;

        public PostController(IPostService _postService, IThreadService _threadService)
        {
            postService = _postService;
            threadService = _threadService;
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


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var threadName = await threadService.GetAllThreadsNameAsync();
            var model = new AddPostFormViewModel
            {
                Threads = threadName
            };

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        
        }

        public async Task<IActionResult> Mine()
        {
            return View();
        }
    }
}
