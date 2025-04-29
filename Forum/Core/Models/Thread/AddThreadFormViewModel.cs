using Forum.Core.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Models.Thread
{
    public class AddThreadViewModel
    {
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; } 

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = null!;
    }
}
