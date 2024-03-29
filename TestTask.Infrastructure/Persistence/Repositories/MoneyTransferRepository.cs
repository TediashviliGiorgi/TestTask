using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;

namespace TestTask.Infrastructure.Persistence.Repositories
{
    public class MoneyTransferRepository : IMoneyTransferRepository
    {
        private readonly AppDbContext _db;

        public MoneyTransferRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(MoneyTransferEntity transfer)
        {
            await _db.MoneyTransfers.AddAsync(transfer);
        }
    }
}
