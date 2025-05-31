using Forum.Core.Contracts;
using Forum.Core.Models.Post;
using Forum.Infrastructure.Common;
using Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;

        public PostService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task AddPostAsync(AddPostFormViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostAllViewModel>> AllPostAsync()
        {
            return await repository
                 .All<Post>()
                 .Select(P => new PostAllViewModel()
                 {
                     Id= P.Id,
                     ImageUrl = P.ImageUrl,
                     Description =P.Description,
                     CreatedAt = P.CreatedAt.ToString()
                 })
                 .ToListAsync();         
        }

        public async Task<PostAllViewModel> PostDetailsById (int id)
        {
            return await repository.AllReadOnly<Post>()
                .Where(p => p.Id == id)
                .Select(p => new PostAllViewModel()
                {
                    Description = p.Description,
                    CreatedAt = p.CreatedAt.ToString()
                    

                }).FirstAsync();
                
        }

        public async Task<bool> ExistByIdAsync(int postId)
        {
            var exist = await repository.All<Post>().AnyAsync(s => s.Id == postId);

            return exist;
        }

      public async Task <int> Create (AddPostFormViewModel model, string userId)
        {
            Post post = new Post()
            {
                UserId = userId,
                ImageUrl = model.ImageUrl,
                Description=model.Description,
                CreatedAt = DateTime.Now,
                ThreadId = model.ThreadId  

            };
            //finish
            await repository.AddAsync(post);
            await repository.SaveChangesAsync();
            return post.Id;

        }

        public async Task <IEnumerable<PostAllViewModel>> AllPostsByUserId(string userId)
        {
            return await repository.AllReadOnly<Post>()
                .Where (p => p.UserId == userId)
                .Select(p => new PostAllViewModel() {
                    Id = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CreatedAt = p.CreatedAt.ToString()
                }).ToListAsync();
               
                
                
                     
        }
        
        public async Task DeleteAsync (int postId)
        {
            await repository.DeleteAsync<Post>(postId);
            await repository.SaveChangesAsync();
        }




    }
}
