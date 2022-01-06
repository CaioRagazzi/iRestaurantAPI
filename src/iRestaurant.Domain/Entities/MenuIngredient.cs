using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class MenuIngredient : AuditableEntity
    {
        public int RestaurantId { get; set; }
        public int MenuId { get; set; }
        public int IngredientId { get; set; }

        public virtual FoodIngredient Ingredient { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
