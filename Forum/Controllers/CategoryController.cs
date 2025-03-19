using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class CategoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
