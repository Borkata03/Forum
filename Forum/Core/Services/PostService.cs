using Forum.Core.Contracts;
using Forum.Core.Models.Post;
using Forum.Infrastructure.Common;
using Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Forum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;

        public PostService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddPostAsync(AddPostFormViewModel model, int userID)
        {
            Post post = new Post()
            {
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CreatedAt = DateTime.Today,
                UserId = model.CreatorId,
                ThreadId = model.ThreadId

            };
            await repository.AddAsync(model);
            await repository.SaveChangesAsync();
               

        }

    

        public async Task<IEnumerable<PostAllViewModel>> AllPostAsync()
        {
            return await repository
                 .All<Post>()
                 .Select(P => new PostAllViewModel()
                 {
                     ImageUrl = P.ImageUrl,
                     Description =P.Description,
                     CreatedAt = P.CreatedAt.ToString()
                 })
                 .ToListAsync();         
        }

        public async Task<bool> ExistByIdAsync(int postId)
        {
            var exist = await repository.All<Post>().AnyAsync(s => s.Id == postId);

            return exist;
        }

        public async Task<bool> ThreadExists(int threadID)
        {
            return true;
        }
    }
}
