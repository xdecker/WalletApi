using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Wallet.Domain.Entities;
using Wallet.Domain.Enums;
using Wallet.Domain.Interfaces;

namespace Wallet.Application.Services
{
    public class MovementService: IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IWalletRepository _walletRepository;

        public MovementService(IMovementRepository movementRepository, IWalletRepository walletRepository)
        {
            _movementRepository = movementRepository;
            _walletRepository = walletRepository;
        }


        public async Task<IEnumerable<MovementHistory>> GetByWalletIdAsync(int walletId)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            if (wallet == null)
                throw new Exception("La billetera especificada no existe.");

            return await _movementRepository.GetByWalletIdAsync(walletId);
        }

        public async Task<(bool Success, string ErrorMessage, MovementHistory Movement)> CreateAsync(MovementHistory movement)
        {
            var wallet = await _walletRepository.GetByIdAsync(movement.walletId);
            if (wallet == null)
                return (false, "La billetera especificada no existe.", null);

            if (movement.type == MovementType.Debit)
            {
                if (wallet.balance < movement.amount)
                    return (false, "Saldo insuficiente para realizar el débito.", null);

                wallet.balance -= movement.amount;
            }
            else if (movement.type == MovementType.Credit)
            {
                wallet.balance += movement.amount;
            }
            else
            {
                return (false, "Tipo de movimiento inválido.", null);
            }

            movement.createdAt = DateTime.Now;
            var created = await _movementRepository.CreateAsync(movement);
            await _walletRepository.UpdateAsync(wallet);

            return (true, null, created);
        }


    }
}
