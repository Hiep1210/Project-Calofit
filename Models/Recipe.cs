using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
            Steps = new HashSet<Step>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!;
        public int Servings { get; set; }
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public string? Description { get; set; }
        public int? ImageId { get; set; }
        public int MenuId { get; set; }

        public virtual Image? Image { get; set; }
        public virtual Menu Menu { get; set; } = null!;
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
