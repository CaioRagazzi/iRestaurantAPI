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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext restaurantContext) : base(restaurantContext)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await DbSet
                .Where(r => r.Email == email)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
