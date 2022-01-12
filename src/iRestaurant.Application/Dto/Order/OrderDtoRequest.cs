using iRestaurant.Application.Dto.OrderMenu;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.Order
{
    public class OrderDtoRequest
    {
        public string Description { get; set; }
        public List<OrderMenuDtoRequest> OrderMenus { get; set; }
    }
}
