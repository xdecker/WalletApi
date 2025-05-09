using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs.Transference;
using Wallet.Application.Interfaces;
using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;

namespace Wallet.Application.Services
{
    public class TransferenceService: ITransferenceService
    {
        private readonly ITransferenceRepository _transferenceRepository;
        private readonly IWalletRepository _walletRepository;

        public TransferenceService(ITransferenceRepository transferenceRepo, IWalletRepository walletRepo)
        {
            _transferenceRepository = transferenceRepo;
            _walletRepository = walletRepo;
        }

        public async Task<(bool Success, string ErrorMessage)> CreateAsync(CreateTransferenceRequest request)
        {
            if (request.FromWalletId == request.ToWalletId)
                return (false, "No se puede transferir a la misma billetera.");

            var fromWallet = await _walletRepository.GetByIdAsync(request.FromWalletId);
            var toWallet = await _walletRepository.GetByIdAsync(request.ToWalletId);

            if (fromWallet == null || toWallet == null)
                return (false, "Una de las billeteras no existe.");

            if (fromWallet.balance < request.Amount)
                return (false, "Saldo insuficiente en la billetera de origen.");

            fromWallet.balance -= request.Amount;
            toWallet.balance += request.Amount;

            var transference = new Transference
            {
                sourceWalletId = request.FromWalletId,
                destinationWalletId = request.ToWalletId,
                amount = request.Amount,
                createdAt = DateTime.Now,
                createdBy = request.CreatedBy
            };

            await _transferenceRepository.CreateAsync(transference);
            await _walletRepository.UpdateAsync(fromWallet);
            await _walletRepository.UpdateAsync(toWallet);

            return (true, null);
        }

        public async Task<IEnumerable<Transference>> GetAllAsync()
        {
            return await _transferenceRepository.GetAllAsync();
        }
    }
}
