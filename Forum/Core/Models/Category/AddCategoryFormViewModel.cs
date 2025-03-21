using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Models.Category
{
    public class AddCategoryFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;


    }
}
