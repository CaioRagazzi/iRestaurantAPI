using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Repository.Repository
{
    public class MenuIngredientRepository : Repository<MenuIngredient>, IMenuIngredientRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public MenuIngredientRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public async Task<MenuIngredient> GetByMenuAndIngredientId(int menuId, int ingredientId)
        {
            var result = await _restaurantContext
                .MenuIngredients
                .Where(mi => mi.MenuId == menuId && mi.IngredientId == ingredientId)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
