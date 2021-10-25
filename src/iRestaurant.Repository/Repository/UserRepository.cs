using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
    }
}
