using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public enum MovementType
    {
        Debit,
        Credit
    }
    public class MovementHistory: BaseEntity
    {
        public long id { get; set; }
        public long walletId { get; set; }
        public decimal amount { get; set; }
        public MovementType type { get; set; }

        public Billetera wallet { get; set; }
    }
}
