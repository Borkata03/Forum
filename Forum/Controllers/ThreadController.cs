using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
