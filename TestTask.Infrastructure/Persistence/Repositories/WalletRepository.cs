using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestTask.Domain.Models;
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

        public async Task CreateAsync(Wallet wallet)
        {
            await _db.Wallets.AddAsync(wallet);
            await _db.SaveChangesAsync();
        }

        public async Task<Wallet> GetByUserIdAsync(int userId)
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