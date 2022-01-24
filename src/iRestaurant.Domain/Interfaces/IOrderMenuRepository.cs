using iRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Domain.Interfaces
{
    public interface IOrderMenuRepository : IRepository<OrderMenu>
    {
        Task<IEnumerable<OrderMenu>> GetByOrderId(int orderId);
    }
}
