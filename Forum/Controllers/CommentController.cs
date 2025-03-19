using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class CommentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
