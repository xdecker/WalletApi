using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public class Transference : BaseEntity
    {
        public long id { get; set; }
        public long sourceWalletId { get; set; }
        public Billetera sourceWallet { get; set; }
        public long destinationWalletId { get; set; }
        public Billetera destinationWallet { get; set; }
        public decimal amount { get; set; }
    }
}
