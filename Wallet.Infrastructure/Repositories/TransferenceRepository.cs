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
    public class TransferenceRepository : ITransferenceRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transference> CreateAsync(Transference transference)
        {
            _context.Transferences.Add(transference);
            await _context.SaveChangesAsync();
            return transference;
        }

        public async Task<IEnumerable<Transference>> GetAllAsync()
        {
            return await _context.Transferences.Where(t => t.isActive)
                .OrderByDescending(t => t.createdAt)
                .ToListAsync();
        }
    }
}
