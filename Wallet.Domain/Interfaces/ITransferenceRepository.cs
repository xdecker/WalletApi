using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Domain.Interfaces
{
    public interface ITransferenceRepository
    {
        Task<Transference> CreateAsync(Transference transference);
        Task<IEnumerable<Transference>> GetAllAsync();
    }
}
