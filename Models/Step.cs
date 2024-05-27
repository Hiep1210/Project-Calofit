using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Step
    {
        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = null!;
        public string? ImageFilename { get; set; }
        public string? ImageType { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
    }
}
