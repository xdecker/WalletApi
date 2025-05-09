using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;

namespace Wallet.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context;

        public WalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Billetera>> GetAllAsync()
        {
            return await _context.Billeteras.Where(w => w.isActive).ToListAsync();
        }

        public async Task<Billetera?> GetByIdAsync(long id)
        {
            return await _context.Billeteras.FirstOrDefaultAsync(w => w.id == id && w.isActive);
        }

        public async Task<Billetera> CreateAsync(Billetera wallet)
        {
            var validDocument = await _context.Users.Where(x => x.isActive && x.documentId == wallet.documentId).AnyAsync();

            if (!validDocument)
            {
                throw new Exception("DocumentId is not valid");
            }

            var documentIsAlreadyUsed = await _context.Billeteras.Where(w => w.isActive && w.documentId == wallet.documentId).AnyAsync();
            if (documentIsAlreadyUsed) 
            {
                throw new Exception("Another wallet already use the DocumentId");
            }

            var createdWallet = await _context.Billeteras.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return createdWallet.Entity;
        }

        public async Task<bool> UpdateAsync(Billetera wallet)
        {
            var validDocument = await _context.Users.Where(x => x.isActive && x.documentId == wallet.documentId).AnyAsync();

            if (!validDocument)
            {
                throw new Exception("DocumentId is not valid");
            }

            var walletToUpdate = await _context.Billeteras.Where(w => w.isActive && w.id == wallet.id).FirstOrDefaultAsync();
            if(walletToUpdate == null)
            {
                return false;
            }

            walletToUpdate.updatedAt = DateTime.Now;
            walletToUpdate.updatedBy = wallet.updatedBy;
            walletToUpdate.balance = wallet.balance;
            walletToUpdate.documentId = wallet.documentId;
            walletToUpdate.name = wallet.name;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var wallet = await _context.Billeteras.FindAsync(id);
            if (wallet == null) return false;

            wallet.deletedAt = DateTime.Now;
            wallet.isActive = false;
            wallet.documentId = wallet.documentId + "_INACTIVE_"+DateTime.Now.Millisecond;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
