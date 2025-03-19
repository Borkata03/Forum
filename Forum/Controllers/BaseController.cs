using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
