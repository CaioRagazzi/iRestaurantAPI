using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Interfaces
{
    public interface IOrderService
    {
        Task Add(OrderDtoRequest orderDtoRequest, int restaurantId);
        Task Update(OrderDtoRequest orderDtoRequest, int orderId);
        Task Delete(int orderId);
        Task<PagedResultDtoResponse<OrderDtoResponse>> GetAll(int restaurantId, int page, int pageSize);
    }
}
