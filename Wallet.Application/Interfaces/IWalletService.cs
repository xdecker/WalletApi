using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Application.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<Billetera>> GetAllAsync();
        Task<Billetera> GetByIdAsync(long id);
        Task<Billetera> CreateAsync(Billetera wallet);
        Task<bool> UpdateAsync(Billetera wallet);
        Task<bool> DeleteAsync(long id);
    }
}
