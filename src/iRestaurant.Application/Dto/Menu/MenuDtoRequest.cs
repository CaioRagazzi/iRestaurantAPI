using iRestaurant.Application.Dto.FoodIngredient;
using iRestaurant.Application.Dto.MenuIngredient;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.Menu
{
    public class MenuDtoRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<MenuIngredientDtoRequest> MenuIngredients { get; set; }
    }
}
