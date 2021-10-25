using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Domain.Models
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }
    }
}
