using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class Order : AuditableEntity
    {
        public Order()
        {
            OrderMenus = new HashSet<OrderMenu>();
        }

        public string Description { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<OrderMenu> OrderMenus { get; set; }
    }
}
