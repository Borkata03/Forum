using Forum.Core.Contracts;
using Forum.Core.Models.Category;
using Forum.Core.Models.Thread;
using Forum.Infrastructure.Common;
using Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Globalization;

namespace Forum.Core.Services
{
    public class ThreadService : IThreadService
    {

        private readonly IRepository repository;

        public ThreadService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<IEnumerable<AllThreadsViewModel>> AllThreadAsync()
        {
            var threads = await repository.All<Infrastructure.Data.Models.Thread>()
               
                .Select(t => new AllThreadsViewModel
                {
                    Name = t.ThreadName,
                    CreatedDate = t.CreatedAt.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                    Category = t.Category.Name 
                })
                .ToListAsync();

            return threads;
        }

        public async Task AddThreadAsync(AddThreadViewModel model, string userId)
        {
            var thread = new Infrastructure.Data.Models.Thread
            {
                ThreadName = model.Name,
                CategoryId = model.CategoryId, 
                UserId = userId,  
                CreatedAt = DateTime.UtcNow 
            };

            await repository.AddAsync(thread);
            await repository.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<ThreadViewModel>> GetAllThreadsNameAsync()
        {
            return await repository.All<Infrastructure.Data.Models.Thread>()
               .Select(t => new ThreadViewModel
               {
                   Id = t.Id,
                   Name = t.ThreadName,
               }).ToListAsync();
        }
    }
}