using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public class User: IdentityUser
    {
        public bool isActive { get; set; }

        public string documentId { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? deletedBy { get; set; }

        public Billetera Billetera { get; set; }
    }
}
