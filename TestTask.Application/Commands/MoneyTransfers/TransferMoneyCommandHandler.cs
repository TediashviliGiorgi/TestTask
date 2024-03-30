using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;


namespace TestTask.Application.Commands.MoneyTransfers
{
    public class TransferMoneyCommandHandler : IRequestHandler<TransferMoneyCommand, BaseResponse<TransferMoneyResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferMoneyCommandHandler(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<TransferMoneyResponse>> Handle(TransferMoneyCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var senderWallet = await _unitOfWork.WalletRepository.GetByUserIdAsync(request.SenderId);
                var receiverWallet = await _unitOfWork.WalletRepository.GetByUserIdAsync(request.ReceiverId);
                var sender = await _unitOfWork.UserRepository.GetByIdAsync(request.SenderId);
                var receiver = await _unitOfWork.UserRepository.GetByIdAsync(request.ReceiverId);

                if (sender == null)
                {
                    return new BaseResponse<TransferMoneyResponse>(false, $"Sender with ID {request.SenderId} not found.", null);
                }

                if (receiver == null)
                {
                    return new BaseResponse<TransferMoneyResponse>(false, $"Receiver with ID {request.ReceiverId} not found.", null);
                }

                if (senderWallet == null)
                {
                    return new BaseResponse<TransferMoneyResponse>(false, "Sender doesn't have a wallet", null);
                }

                if (receiverWallet == null)
                {
                    return new BaseResponse<TransferMoneyResponse>(false, "Receiver doesn't have a wallet", null);
                }

                if (request.SenderId == request.ReceiverId)
                {
                    return new BaseResponse<TransferMoneyResponse>(false, "Internal Transaction not allowed", null);
                }

                if (senderWallet.Balance < request.Amount)
                {
                    return new BaseResponse<TransferMoneyResponse>(false, "Not enough money", null);
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

                var response = new TransferMoneyResponse()
                {
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    Amount = request.Amount,
                };


                return new BaseResponse<TransferMoneyResponse>(true, "Transfer successfully", response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return new BaseResponse<TransferMoneyResponse>(false, ex.Message, null);
            }
        }
    }
}

