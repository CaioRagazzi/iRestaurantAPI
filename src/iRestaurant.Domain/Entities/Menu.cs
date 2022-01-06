using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class Menu : AuditableEntity
    {
        public Menu()
        {
            MenuIngredients = new HashSet<MenuIngredient>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }

        public virtual FoodCategory Category { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<MenuIngredient> MenuIngredients { get; set; }
    }
}
