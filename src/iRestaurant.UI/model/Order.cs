using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.UI.model
{
    public partial class Order
    {
        public Order()
        {
            OrderMenus = new HashSet<OrderMenu>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }
        public int RestaurantId { get; set; }
        public bool? Deleted { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<OrderMenu> OrderMenus { get; set; }
    }
}
