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
    public class OrderMenuRepository : Repository<OrderMenu>, IOrderMenuRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public OrderMenuRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public async Task<IEnumerable<OrderMenu>> GetByOrderId(int orderId)
        {
            var orderMenus = await DbSet
                .Where(r => r.OrderId == orderId)
                .ToListAsync();

            return orderMenus;
        }
    }
}
