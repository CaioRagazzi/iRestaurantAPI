using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Domain.Interfaces
{
    public interface IOrderRepository :  IRepository<Order>
    {
        Task<PagedResult<Order>> GetAllFilteredByRestaurantId(int restaurantId, int page, int pageSize);
    }
}
