using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.OrderMenu
{
    public class OrderMenuDtoRequest
    {
        public string AdditionalComment { get; set; }
        public int Quantity { get; set; }
        public int MenuId { get; set; }
    }
}
