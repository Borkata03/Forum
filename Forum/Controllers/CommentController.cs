using Forum.Core.Contracts;
using Forum.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

namespace Forum.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IPostService postService;
        private readonly PredictionEngine<CommentData, CommentPrediction> predEngine;

        public CommentController(ICommentService commentService, IPostService postService, PredictionEngine<CommentData, CommentPrediction> predEngine)
        {
            this.commentService = commentService;
            this.postService = postService;
            this.predEngine = predEngine;
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
                return View(model);

            var prediction = predEngine.Predict(new CommentData { Content = model.Content });

            if (prediction.IsToxic)
            {
                ModelState.AddModelError(nameof(model.Content), "The comment contains inappropriate or toxic language.");
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
