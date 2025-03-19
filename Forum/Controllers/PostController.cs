using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class PostController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
