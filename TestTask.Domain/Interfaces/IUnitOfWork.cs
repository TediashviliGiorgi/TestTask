using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IWalletRepository WalletRepository { get; }
        IUserRepository UserRepository { get; }
        IMoneyTransferRepository MoneyTransferRepository { get; }
        Task SaveChangesAsync();
    }
}
