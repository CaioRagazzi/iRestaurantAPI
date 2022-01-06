using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.UI.model
{
    public partial class MenuIngredient
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }
        public int RestaurantId { get; set; }
        public bool? Deleted { get; set; }
        public int MenuId { get; set; }
        public int IngredientId { get; set; }

        public virtual FoodIngredient Ingredient { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
