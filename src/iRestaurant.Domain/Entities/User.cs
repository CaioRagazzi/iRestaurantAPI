using iRestaurant.Domain.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace iRestaurant.Domain.Entities
{
    public partial class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TypeAuth { get; set; }
    }
}
