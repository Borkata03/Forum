using Forum.Core.Models.Category;

namespace Forum.Core.Contracts
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(AddCategoryFormViewModel model);


    }
}
