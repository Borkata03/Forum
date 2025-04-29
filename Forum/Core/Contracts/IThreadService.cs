using Forum.Core.Models.Thread;

namespace Forum.Core.Contracts
{
    public interface IThreadService
    {
        public Task<IEnumerable<AllThreadsViewModel>> AllThreadAsync();

        public Task AddThreadAsync(AddThreadViewModel model, string userId);

        public Task<IEnumerable<ThreadViewModel>> GetAllThreadsNameAsync();
    }
}
