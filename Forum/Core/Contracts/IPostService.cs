using Forum.Core.Models.Post;

namespace Forum.Core.Contracts
{
    public interface IPostService
    {

        Task<IEnumerable<PostAllViewModel>> AllPostAsync();

        Task<PostAllViewModel> PostDetailsById(int id);


		Task<bool> ExistByIdAsync(int postId);

        Task AddPostAsync(AddPostFormViewModel model);

    }
}
