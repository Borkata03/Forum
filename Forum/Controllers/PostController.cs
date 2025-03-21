using Forum.Core.Contracts;
using Forum.Core.Models.Post;
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

        /* [HttpGet]
         public async Task <IActionResult> Add()
         {
         

         }
        */

       /* [HttpPost]

        public async Task <IActionResult> Add(AddPostFormViewModel model)
        {

            //check if the thread ID exists

            //get and post
        }
       */
        public IActionResult Index()
        {
            return View();
        }
    }
}
