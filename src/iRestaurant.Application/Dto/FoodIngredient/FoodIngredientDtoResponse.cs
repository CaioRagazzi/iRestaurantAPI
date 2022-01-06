using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.FoodIngredient
{
    public class FoodIngredientDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }
    }
}
