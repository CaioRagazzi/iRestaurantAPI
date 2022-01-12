using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Repository.Repository
{
    public class OrderMenuRepository : Repository<OrderMenu>, IOrderMenuRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public OrderMenuRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
    }
}
