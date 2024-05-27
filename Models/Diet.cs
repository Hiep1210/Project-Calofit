using System;
using System.Collections.Generic;

namespace Calofit_Project.Models
{
    public partial class Diet
    {
        public Diet()
        {
            Menus = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string DietName { get; set; } = null!;

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
