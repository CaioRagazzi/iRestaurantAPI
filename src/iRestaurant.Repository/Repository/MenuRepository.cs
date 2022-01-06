using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iRestaurant.Domain.Models;
using iRestaurant.Repository.Extensions;

namespace iRestaurant.Repository.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public MenuRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public override async Task<Menu> GetById(int id)
        {
            return await DbSet
                .Include(r => r.MenuIngredients)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedResult<Menu>> GetAllFilteredByRestaurantId(int restaurantId, int page, int pageSize)
        {
            var result = await _restaurantContext.Menus
                .Where(r => r.RestaurantId == restaurantId)
                .Include(r => r.MenuIngredients)
                .GetPaged(page, pageSize);

            return result;
        }
    }
}
