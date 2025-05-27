using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Constants
{
    public class DataConstants
    {
        public const int ThreadNameMaxLength = 25;
        public const int ThreadNameMinLength = 5;

        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 25;

        public const int CommentReportMaxLength = 3000;

        public const int PostDescriptionMinLength = 15;
        public const int PostDescriptionMaxLength = 5000;

    }
}
