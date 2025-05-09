using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public class Billetera : BaseEntity
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal balance { get; set; }

        public string documentId { get; set; }
        public User User { get; set; }

        public ICollection<MovementHistory> movements { get; set; }

    }
}
