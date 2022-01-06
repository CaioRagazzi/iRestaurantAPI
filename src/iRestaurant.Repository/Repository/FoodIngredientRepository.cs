using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Domain.Models;
using iRestaurant.Repository.Context;
using iRestaurant.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Repository.Repository
{
    class FoodIngredientRepository : Repository<FoodIngredient>, IFoodIngredientRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public FoodIngredientRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public async Task<PagedResult<FoodIngredient>> GetAllFilteredByRestaurantId(int restaurantId, int page, int pageSize)
        {
            var result = await _restaurantContext.FoodIngredients
                .Where(r => r.RestaurantId == restaurantId)
                .GetPaged(page, pageSize);

            return result;
        }
    }
}
