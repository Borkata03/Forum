using Microsoft.ML;
using Microsoft.ML.Data;
using CommentToxicityTrainer.ModelML;

class Program
{
    static void Main()
    {
        var mlContext = new MLContext();

     
        var dataPath = "C:\\Users\\bvasi\\source\\repos\\Forum\\CommentTrainer\\comments.csv.txt";
        var dataView = mlContext.Data.LoadFromTextFile<CommentData>(
            path: dataPath,
            hasHeader: true,
            separatorChar: ','
        );

     
        var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(CommentData.Content))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: nameof(CommentData.IsToxic), featureColumnName: "Features"));

     
        var model = pipeline.Fit(dataView);

        mlContext.Model.Save(model, dataView.Schema, @"C:\Users\bvasi\source\repos\Forum\model.zip");
        Console.WriteLine("Model trained and saved as model.zip");

   
        var predEngine = mlContext.Model.CreatePredictionEngine<CommentData, CommentPrediction>(model);
        var sample = new CommentData { Content = "You are stupid" };
        var prediction = predEngine.Predict(sample);
        Console.WriteLine($"Comment: {sample.Content} | IsToxic: {prediction.IsToxic}");
    }
}
