using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Repository.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public int? TypeAuth { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
