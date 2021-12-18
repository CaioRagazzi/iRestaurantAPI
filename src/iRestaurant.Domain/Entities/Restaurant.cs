using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class Restaurant : AuditableEntity
    {
        public Restaurant()
        {
            FoodCategories = new HashSet<FoodCategory>();
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<FoodCategory> FoodCategories { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
