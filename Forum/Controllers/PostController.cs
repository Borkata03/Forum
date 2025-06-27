using Forum.Core.Contracts;
using Forum.Core.Models.Post;
using Forum.Core.Services;
using Forum.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly IThreadService threadService;
        private readonly ICommentService commentService;

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
        public async Task<IActionResult> Details(int id)
        {
            if (await postService.ExistByIdAsync(id) == false)

            {
                return BadRequest();
            }
            var model = await postService.PostDetailsById(id);

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

        [HttpPost]
        public async Task<IActionResult> Add(AddPostFormViewModel model)
        {

            int  postId = await postService.Create(model, User.Id());

            return RedirectToAction(nameof(Details), new {id = postId});
           //finish
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();

            IEnumerable<PostAllViewModel> model;

            model = await postService.AllPostsByUserId(userId);

            return View(model);


        }

        [HttpGet]
        public async Task <IActionResult> Delete (int id)
        {

            if (await postService.ExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var post = await postService.PostDetailsById(id);

            var model = new PostAllViewModel()
            {
                Id = post.Id,
                Description = post.Description,
                ImageUrl = post.ImageUrl,
                CreatedAt = post.CreatedAt
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete (PostAllViewModel model)
        {
            if (await postService.ExistByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var commentsToDelete = await commentService.GetCommentsByPostIdAsync(model.Id);
            foreach(var comment in commentsToDelete)
            {
                await commentService.DeleteAsync(comment.Id);
            }


            await postService.DeleteAsync(model.Id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Comment(int postId)
        {
            var model = new CommentFormModel
            {
                PostId = postId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await commentService.AddCommentAsync(model, userId);

            return RedirectToAction("Details", "Post", new { id = model.PostId });
        }



    }
}
