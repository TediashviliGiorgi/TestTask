using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;

namespace TestTask.Infrastructure.Persistence.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _db;

        public WalletRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(WalletEntity wallet)
        {
            await _db.Wallets.AddAsync(wallet);
            await _db.SaveChangesAsync();
        }

        public async Task<WalletEntity> GetByUserIdAsync(int userId)
        {
            return await _db.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task UpdateBalanceAsync(int walletId, decimal newBalance)
        {
            var wallet = await _db.Wallets.FindAsync(walletId);
            if (wallet != null)
            {
                wallet.Balance = newBalance;
                await _db.SaveChangesAsync();
            }
        }
    }
}
