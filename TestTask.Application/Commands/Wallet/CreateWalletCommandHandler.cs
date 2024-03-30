using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;

namespace TestTask.Application.Commands.Wallet
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, BaseResponse<CreateWalletResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWalletCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<CreateWalletResponse>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

                if (user == null)
                {
                    return new BaseResponse<CreateWalletResponse>(false, "User not found.", null);
                }

                if (user.Wallet != null)
                {
                    return new BaseResponse<CreateWalletResponse>(false, "User already has a wallet.", null);
                }

                var wallet = new WalletEntity
                {
                    UserId = request.UserId,
                    Balance = request.Balance
                };

                await _unitOfWork.WalletRepository.CreateAsync(wallet);
                user.Wallet = wallet;
                await _unitOfWork.SaveChangesAsync();

                var response = new CreateWalletResponse
                {
                    UserId = wallet.UserId,
                    Balance = wallet.Balance
                };

                return new BaseResponse<CreateWalletResponse>(true, "Wallet created successfully.", response);
            }
            catch (Exception ex)
            {
               
                return new BaseResponse<CreateWalletResponse>(false, ex.Message, null);
            }
        }
    }
}
