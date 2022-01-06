using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class FoodIngredient : AuditableEntity
    {
        public FoodIngredient()
        {
            MenuIngredients = new HashSet<MenuIngredient>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<MenuIngredient> MenuIngredients { get; set; }
    }
}
