using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class OrderMenu : AuditableEntity
    {
        public string AdditionalComment { get; set; }
        public int Quantity { get; set; }
        public int RestaurantId { get; set; }   
        public int OrderId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
