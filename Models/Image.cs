using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Image
    {
        public Image()
        {
            Ingredients = new HashSet<Ingredient>();
            Recipes = new HashSet<Recipe>();
        }

        public string? ImageFilename { get; set; }
        public int ImageId { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
