using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public class BaseEntity
    {
        
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public bool isActive { get; set; } = true;
        public string createdBy { get; set; }
        public string? updatedBy { get; set; }
        public string? deletedBy { get; set; }
    }
}
