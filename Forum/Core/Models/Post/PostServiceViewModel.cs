using Forum.Core.Models.Thread;

namespace Forum.Core.Models.Post
{
    public class PostServiceViewModel
    {
        public int Id { get; set; }


        public string ImageUrl { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;

    }
}
