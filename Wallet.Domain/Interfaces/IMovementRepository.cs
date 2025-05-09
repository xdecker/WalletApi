using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Domain.Interfaces
{
    public interface IMovementRepository
    {
        Task<IEnumerable<MovementHistory>> GetByWalletIdAsync(long walletId);
        Task<MovementHistory> CreateAsync(MovementHistory movement);
    }
}
