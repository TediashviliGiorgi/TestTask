using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Interfaces
{
    public interface IWalletRepository
    {
        Task<WalletEntity> GetByUserIdAsync(int userId);
        Task UpdateBalanceAsync(int walletId, decimal newBalance);
        Task CreateAsync(WalletEntity wallet);
    }
}
