using Forum.Core.Models.Post;

namespace Forum.Core.Contracts
{
    public interface IPostService
    {

        Task<IEnumerable<PostAllViewModel>> AllPostAsync();

        Task<bool> ExistByIdAsync(int postId);

        Task AddPostAsync(AddPostFormViewModel model, int userID);

        Task<bool> ThreadExists(int threadID);
        

    }
}
