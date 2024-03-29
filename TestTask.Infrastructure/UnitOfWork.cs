using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Interfaces;
using TestTask.Infrastructure.Persistence.Repositories;

namespace TestTask.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        public IWalletRepository WalletRepository => new WalletRepository(_db);
        public IUserRepository UserRepository => new UserRepository(_db);
        public IMoneyTransferRepository MoneyTransferRepository => new MoneyTransferRepository(_db);



        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
