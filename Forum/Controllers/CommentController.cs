using Forum.Core.Contracts;
using Forum.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IPostService postService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public IActionResult Create(int postId)
        {
            var model = new CommentFormModel { PostId = postId };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await commentService.AddCommentAsync(model, User.Id());
            return RedirectToAction("Details", "Post", new { id = model.PostId });
        }


        [HttpPost]

        public async Task<IActionResult> Delete(CommentDeleteModel model)
        {

            await commentService.DeleteAsync(model.Id);


            return RedirectToAction("Details", "Post", new { id = model.PostId });


        }



    }
}
