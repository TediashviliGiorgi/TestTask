using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;


namespace TestTask.Application.Commands.MoneyTransfers
{
    public class TransferMoneyCommandHandler : IRequestHandler<TransferMonneyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferMoneyCommandHandler(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(TransferMonneyCommand request, CancellationToken cancellationToken)
        {
            var senderWallet = await _unitOfWork.WalletRepository.GetByUserIdAsync(request.SenderId);
            var receiverWallet = await _unitOfWork.WalletRepository.GetByUserIdAsync(request.ReceiverId);
            var sender = await _unitOfWork.UserRepository.GetByIdAsync(request.SenderId);
            var receiver = await _unitOfWork.UserRepository.GetByIdAsync(request.ReceiverId);

            if (sender == null)
            {
                throw new Exception($"Sender with ID {request.SenderId} not found.");
            }

            if (receiver == null)
            {
                throw new Exception($"Receiver with ID {request.ReceiverId} not found.");
            }

            if (senderWallet == null)
            {
                throw new Exception("Sender doesn't have a wallet");
            }

            if (receiverWallet == null)
            {
                throw new Exception("Receiver doesn't have a wallet");
            }

            if (request.SenderId == request.ReceiverId)
            {
                throw new Exception("Internal Transaction not allowed");
            }

            if (senderWallet.Balance < request.Amount)
            {
                throw new Exception("Not enough money");
            }
          

            

            senderWallet.Balance -= request.Amount;
            receiverWallet.Balance += request.Amount;

            var transfer = new MoneyTransferEntity
            {
                SenderUserId = request.SenderId,
                ReceiverUserId = request.ReceiverId,
                Amount = request.Amount,
                TransferDate = DateTime.UtcNow,
            };

            await _unitOfWork.MoneyTransferRepository.AddAsync(transfer);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
