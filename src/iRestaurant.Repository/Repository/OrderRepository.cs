using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Domain.Models;
using iRestaurant.Repository.Context;
using iRestaurant.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Repository.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public OrderRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public async Task<PagedResult<Order>> GetAllFilteredByRestaurantId(int restaurantId, int page, int pageSize)
        {
            var result = await _restaurantContext.Orders
                .Where(r => r.RestaurantId == restaurantId)
                .Include(r => r.OrderMenus).ThenInclude(r => r.Menu).ThenInclude(r => r.Category)
                .Include(r => r.OrderMenus).ThenInclude(r => r.Menu).ThenInclude(r => r.MenuIngredients)
                .OrderBy(r => r.Id)
                .GetPaged(page, pageSize);

            return result;
        }
    }
}
