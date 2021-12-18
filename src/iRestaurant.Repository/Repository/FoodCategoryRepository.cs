using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Domain.Models;
using iRestaurant.Repository.Context;
using iRestaurant.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.Repository.Repository
{
    public class FoodCategoryRepository : Repository<FoodCategory>, IFoodCategoryRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public FoodCategoryRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public async Task<PagedResult<FoodCategory>> GetAllFilteredByRestaurantId(int restaurantId, int page, int pageSize)
        {
            var result = await _restaurantContext.FoodCategories
                .Where(r => r.RestaurantId == restaurantId)
                .GetPaged(page, pageSize);

            return result;
        }
    }
}
