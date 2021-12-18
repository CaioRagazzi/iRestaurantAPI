using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.UI.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            FoodCategories = new HashSet<FoodCategory>();
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<FoodCategory> FoodCategories { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
