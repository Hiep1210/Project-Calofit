using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientServingSizes = new HashSet<IngredientServingSize>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int IngredientId { get; set; }
        public string Name { get; set; } = null!;
        public int ImageId { get; set; }

        public virtual Image Image { get; set; } = null!;
        public virtual Nutrition? Nutrition { get; set; }
        public virtual ICollection<IngredientServingSize> IngredientServingSizes { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
