using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class IngredientServingSize
    {
        public IngredientServingSize()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int ServingSizeId { get; set; }
        public int IngredientId { get; set; }
        public double Qty { get; set; }
        public double Scale { get; set; }
        public string Units { get; set; } = null!;
        public double Grams { get; set; }
        public string? Description { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
