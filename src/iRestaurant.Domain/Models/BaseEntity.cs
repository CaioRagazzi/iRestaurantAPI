using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
