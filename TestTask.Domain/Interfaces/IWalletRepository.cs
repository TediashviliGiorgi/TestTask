using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Models;

namespace TestTask.Domain.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> GetByUserIdAsync(int userId);
        Task UpdateBalanceAsync(int walletId, decimal newBalance);
        Task CreateAsync(Wallet wallet);
    }
}
