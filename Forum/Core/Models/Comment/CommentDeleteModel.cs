using System.ComponentModel.DataAnnotations;

public class CommentDeleteModel
{
    public int Id { get; set; }
    public string Content { get; set; }

    public int PostId { get; set; }
}