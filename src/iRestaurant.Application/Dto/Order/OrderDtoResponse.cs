using iRestaurant.Application.Dto.OrderMenu;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.Order
{
    public class OrderDtoResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderMenuDtoResponse> OrderMenus { get; set; }
    }
}
