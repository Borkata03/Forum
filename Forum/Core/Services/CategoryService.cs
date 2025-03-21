﻿using Forum.Core.Contracts;
using Forum.Core.Models.Category;
using Forum.Infrastructure.Common;
using Forum.Infrastructure.Data.Models;
using Forum.Extensions;
using Microsoft.DiaSymReader;

namespace Forum.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task AddCategoryAsync(AddCategoryFormViewModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
                CreatorId = model.UserId
            };

           await repository.AddAsync<Category>(category);
           await repository.SaveChangesAsync();


        }
    }
}
