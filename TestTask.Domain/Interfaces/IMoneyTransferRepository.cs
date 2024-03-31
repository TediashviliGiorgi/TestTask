using TestTask.Domain.Models;

namespace TestTask.Domain.Interfaces
{
    public interface IMoneyTransferRepository
    {
        Task AddAsync(MoneyTransfer transfer);
    }
}
