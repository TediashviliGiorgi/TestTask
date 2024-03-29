using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Interfaces;

namespace TestTask.Application.Commands.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.UserRepository.RemoveAsync(request.UserId);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
