using AutoMapper;
using iRestaurant.Application.Dto;
using iRestaurant.Application.Dto.Order;
using iRestaurant.Application.Interfaces;
using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderMenuRepository _orderMenuRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderMenuRepository orderMenuRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderMenuRepository = orderMenuRepository;
            _mapper = mapper;
        }

        public async Task Add(OrderDtoRequest orderDtoRequest, int restaurantId)
        {
            var order = _mapper.Map<Order>(orderDtoRequest);
            order.RestaurantId = restaurantId;
            order.OrderMenus = new List<OrderMenu>();

            _orderRepository.Insert(order);
            await _orderRepository.Save();

            orderDtoRequest.OrderMenus.ToList().ForEach(orderMenu =>
            {
                var orderMenuToAdd = new OrderMenu
                {
                    RestaurantId = restaurantId,
                    AdditionalComment = orderMenu.AdditionalComment,
                    MenuId = orderMenu.MenuId,
                    OrderId = order.Id,
                    Quantity = orderMenu.Quantity,
                };
                _orderMenuRepository.Insert(orderMenuToAdd);
            });

            await _orderMenuRepository.Save();
        }

        public async Task Update(OrderDtoRequest orderDtoRequest, int orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            order.Description = orderDtoRequest.Description;

            var orderMenus = await _orderMenuRepository.GetByOrderId(orderId);

            orderMenus.ToList().ForEach(orderMenu =>
            {
                _orderMenuRepository.RemoveCompletelly(orderMenu);
            });
            await _orderMenuRepository.Save();

            orderDtoRequest.OrderMenus.ToList().ForEach(orderMenu =>
            {
                var orderMenuToAdd = new OrderMenu
                {
                    RestaurantId = order.RestaurantId,
                    AdditionalComment = orderMenu.AdditionalComment,
                    MenuId = orderMenu.MenuId,
                    OrderId = order.Id,
                    Quantity = orderMenu.Quantity,
                };
                _orderMenuRepository.Insert(orderMenuToAdd);
            });

            await _orderMenuRepository.Save();
        }

        public async Task Delete(int orderId)
        {
            var menu = await _orderRepository.GetById(orderId);

            menu.Deleted = true;

            await _orderRepository.Save();
        }

        public async Task<PagedResultDtoResponse<OrderDtoResponse>> GetAll(int restaurantId, int page, int pageSize)
        {
            var pagedResult = await _orderRepository.GetAllFilteredByRestaurantId(restaurantId, page, pageSize);
            var pagedResultDtoResponse = _mapper.Map<PagedResultDtoResponse<OrderDtoResponse>>(pagedResult);

            return pagedResultDtoResponse;
        }
    }
}
