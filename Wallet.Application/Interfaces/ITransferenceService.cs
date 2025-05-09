using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs.Transference;
using Wallet.Domain.Entities;

namespace Wallet.Application.Interfaces
{
    public interface ITransferenceService
    {
        Task<(bool Success, string ErrorMessage)> CreateAsync(CreateTransferenceRequest request);
        Task<IEnumerable<Transference>> GetAllAsync();
    }
}
