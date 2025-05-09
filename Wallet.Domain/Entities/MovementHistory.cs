using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wallet.Domain.Enums;

namespace Wallet.Domain.Entities
{

    public class MovementHistory: BaseEntity
    {
        public long id { get; set; }
        public long walletId { get; set; }
        public decimal amount { get; set; }
        public MovementType type { get; set; }

        [JsonIgnore]
        public Billetera wallet { get; set; }
    }
}
