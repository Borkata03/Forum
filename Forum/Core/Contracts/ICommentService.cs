namespace Forum.Core.Contracts
{
    public interface ICommentService
    {

        public Task AddCommentAsync(CommentFormModel model, string userId);

        Task<IEnumerable<CommentViewModel>> GetCommentsByPostIdAsync(int postId);

        Task DeleteAsync(int commendId);
    }
}
