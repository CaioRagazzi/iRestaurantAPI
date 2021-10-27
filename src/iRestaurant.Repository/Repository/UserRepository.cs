using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using iRestaurant.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {

        }
    }
}
