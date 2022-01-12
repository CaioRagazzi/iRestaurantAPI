using iRestaurant.Application.Dto.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.OrderMenu
{
    public class OrderMenuDtoResponse
    {
        public string AdditionalComment { get; set; }
        public int Quantity { get; set; }
        public int RestaurantId { get; set; }
        public int MenuId { get; set; }

        public virtual MenuDtoResponse Menu { get; set; }
    }
}
