using iRestaurant.Application.Dto.Order;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var response = await _orderService.GetAll(int.Parse(User.FindFirst("RestaurantId")?.Value), page, pageSize);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDtoRequest orderDtoRequest)
        {
            await _orderService.Add(orderDtoRequest, int.Parse(User.FindFirst("RestaurantId")?.Value));

            return Ok();
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update(OrderDtoRequest orderDtoRequest, int orderId)
        {
            await _orderService.Update(orderDtoRequest, orderId);

            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            await _orderService.Delete(orderId);

            return Ok();
        }
    }
}
