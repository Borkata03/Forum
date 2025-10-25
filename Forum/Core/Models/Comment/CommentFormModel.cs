using System.ComponentModel.DataAnnotations;

public class CommentFormModel
{
    [Required]
    [StringLength(500, MinimumLength = 1)]
    public string? Content { get; set; }

    public int PostId { get; set; }
}