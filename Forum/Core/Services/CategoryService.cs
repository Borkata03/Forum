using Forum.Core.Contracts;
using Forum.Core.Models.Category;
using Forum.Infrastructure.Common;
using Forum.Infrastructure.Data.Models;
using Forum.Extensions;
using Microsoft.DiaSymReader;
using Microsoft.EntityFrameworkCore;

namespace Forum.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesForDropdownAsync()
        {
            return await repository.All<Category>()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
