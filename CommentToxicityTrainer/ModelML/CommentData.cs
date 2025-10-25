using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentToxicityTrainer.ModelML
{
    public class CommentData
    {
        [LoadColumn(0)] public string? Content { get; set; }
        [LoadColumn(1)] public bool IsToxic { get; set; }
    }
}
