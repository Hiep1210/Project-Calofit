using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int ServingSizeId { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual Recipe Recipe { get; set; } = null!;
        public virtual IngredientServingSize ServingSize { get; set; } = null!;
    }
}
