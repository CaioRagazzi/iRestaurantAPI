using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Repository.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
        }
    }
}
