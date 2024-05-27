using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string MenuName { get; set; } = null!;
        public int DietId { get; set; }

        public virtual Diet Diet { get; set; } = null!;
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
