using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Nutrition
    {
        public int IngredientId { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double Sugar { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
