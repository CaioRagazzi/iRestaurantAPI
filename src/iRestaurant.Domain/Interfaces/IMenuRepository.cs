using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Domain.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<PagedResult<Menu>> GetAllFilteredByRestaurantId(int restaurantId, int page, int pageSize);
    }
}
