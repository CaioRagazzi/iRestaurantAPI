using iRestaurant.Application.Dto.FoodIngredient;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.MenuIngredient
{
    public class MenuIngredientDtoRequest
    {
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
    }
}
