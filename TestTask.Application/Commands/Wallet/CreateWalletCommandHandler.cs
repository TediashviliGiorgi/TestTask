using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;

namespace TestTask.Application.Commands.Wallet
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWalletCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var wallet = new WalletEntity
            {
                UserId = request.UserId,
                Balance = request.Balance
            };

            await _unitOfWork.WalletRepository.CreateAsync(wallet);

            user.Wallet = wallet;
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
