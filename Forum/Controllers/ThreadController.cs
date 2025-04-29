using Forum.Core.Contracts;
using Forum.Core.Models.Thread;
using Forum.Core.Services;
using Forum.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : BaseController
    {
        private readonly IThreadService threadService;
        private readonly ICategoryService categoryService;


        public ThreadController(IThreadService _threadService, ICategoryService _categoryService)
        {
            threadService = _threadService;
            categoryService = _categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var threads = await threadService.AllThreadAsync();
            return View(threads);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
          
            var categoryViewModels = await categoryService.GetCategoriesForDropdownAsync();

          
            var model = new AddThreadViewModel
            {
                Categories = categoryViewModels
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddThreadViewModel model)
        {
            await threadService.AddThreadAsync(model, User.Id());


            return RedirectToAction(nameof(All));
        }



    }
}
