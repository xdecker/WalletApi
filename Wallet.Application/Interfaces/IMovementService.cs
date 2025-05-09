using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Application.Interfaces
{
    public interface IMovementService
    {
        Task<IEnumerable<MovementHistory>> GetByWalletIdAsync(int walletId);
        Task<(bool Success, string ErrorMessage, MovementHistory Movement)> CreateAsync(MovementHistory movement);
    }
}
