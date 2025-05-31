using System.Drawing;

namespace Forum.Core.Models.Post
{
    public class PostAllViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;

        public List<CommentViewModel> Comments { get; set; } = new();


    }
}
