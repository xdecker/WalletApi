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
    public class MovementRepository : IMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public MovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovementHistory>> GetByWalletIdAsync(long walletId)
        {
            

            return await _context.MovementsHistory
                .Where(m => m.walletId == walletId && m.isActive).ToListAsync();
                
        }

        public async Task<MovementHistory> CreateAsync(MovementHistory movement)
        {
            _context.MovementsHistory.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }
    }
}
