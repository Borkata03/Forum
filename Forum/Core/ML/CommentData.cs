using Microsoft.ML.Data;


public class CommentData
{
    [LoadColumn(0)]
    public string? Content { get; set; }

    [LoadColumn(1)]
    public bool IsToxic { get; set; }
}

