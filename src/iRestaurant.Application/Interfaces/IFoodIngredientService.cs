using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.FoodIngredient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IFoodIngredientService
    {
        Task Add(FoodIngredientDtoRequest foodIngredientDtoRequest, int restaurantId);
        Task Update(FoodIngredientDtoRequest foodIngredientDtoRequest, int foodIngredientId);
        Task Delete(int foodCategoryId);
        Task<PagedResultDtoResponse<FoodIngredientDtoResponse>> GetAll(int restaurantId, int page, int pageSize);
    }
}
