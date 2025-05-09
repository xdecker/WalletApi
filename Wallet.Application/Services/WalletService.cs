using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;

namespace Wallet.Application.Services
{
    public class WalletService: IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<IEnumerable<Billetera>> GetAllAsync()
        {
            return await _walletRepository.GetAllAsync();
        }

        public async Task<Billetera?> GetByIdAsync(long id)
        {
            return await _walletRepository.GetByIdAsync(id);
        }

        public async Task<Billetera> CreateAsync(Billetera wallet)
        {
            return await _walletRepository.CreateAsync(wallet);
        }

        public async Task<bool> UpdateAsync(Billetera wallet)
        {
            return await _walletRepository.UpdateAsync(wallet);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _walletRepository.DeleteAsync(id);
        }
    }
}
