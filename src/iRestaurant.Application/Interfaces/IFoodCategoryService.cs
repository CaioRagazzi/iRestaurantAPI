using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.FoodCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IFoodCategoryService
    {
        Task Add(FoodCategoryDtoRequest foodCategoryDtoRequest, int restaurantId);
        Task Update(FoodCategoryDtoRequest foodCategoryDtoRequest, int foodCategoryId);
        Task Delete(int foodCategoryId);
        Task<PagedResultDtoResponse<FoodCategoryDtoResponse>> GetAll(int restaurantId, int page, int pageSize);
    }
}
