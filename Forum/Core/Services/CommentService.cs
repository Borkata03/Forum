using Forum.Core.Contracts; 
using Forum.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

public class CommentService : ICommentService
{
    private readonly IRepository repository;

    public CommentService(IRepository repository)
    {
        this.repository = repository;
    }

    public async Task AddCommentAsync(CommentFormModel model, string userId)
    {
        var comment = new Comment
        {
            Content = model.Content,
            PostId = model.PostId,
            UserId = userId
        };

        await repository.AddAsync(comment);
        await repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<CommentViewModel>> GetCommentsByPostIdAsync(int postId)
    {
        return await repository.AllReadOnly<Comment>()
            .Where(c => c.PostId == postId)
            .Select(c => new CommentViewModel
            {
                Content = c.Content,
                UserName = c.User.UserName,
                CreatedAt = c.Post.CreatedAt.ToString("dd MMM yyyy")
            }).ToListAsync();
    }


    public async Task DeleteAsync(int commentId)
    {

        await repository.DeleteAsync<Comment>(commentId);
        await repository.SaveChangesAsync();
    }

}
