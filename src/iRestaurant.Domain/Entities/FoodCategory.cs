using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class FoodCategory : AuditableEntity
    {
        public FoodCategory()
        {
            Menus = new HashSet<Menu>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
