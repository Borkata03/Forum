using Forum.Core.Models.Post;

namespace Forum.Core.Contracts
{
    public interface IPostService
    {

        Task<IEnumerable<PostAllViewModel>> AllPostAsync();

        Task<PostAllViewModel> PostDetailsById(int id);


		Task<bool> ExistByIdAsync(int postId);

        Task AddPostAsync(AddPostFormViewModel model);

        public Task<int> Create(AddPostFormViewModel model, string UserId);

        public Task<IEnumerable<PostAllViewModel>> AllPostsByUserId(string userId);

        public Task DeleteAsync(int postId);

      



    }
}
