using Microsoft.ML.Data;
public class CommentPrediction
{
    [ColumnName("PredictedLabel")]
    public bool IsToxic { get; set; }
}