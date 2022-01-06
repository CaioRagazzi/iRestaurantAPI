using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.MenuIngredient
{
    public class MenuIngredientDtoResponse
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int MenuId { get; set; }
        public int IngredientId { get; set; }
    }
}
