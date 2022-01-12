using iRestaurant.Application.Dto.FoodCategory;
using iRestaurant.Application.Dto.MenuIngredient;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.Menu
{
    public class MenuDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<MenuIngredientDtoResponse> MenuIngredients { get; set; }
        public FoodCategoryDtoResponse Category { get; set; }
    }
}
