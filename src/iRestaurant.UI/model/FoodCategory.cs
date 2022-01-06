using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.UI.model
{
    public partial class FoodCategory
    {
        public FoodCategory()
        {
            Menus = new HashSet<Menu>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public bool? Deleted { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
