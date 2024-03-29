using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Services.Hashing;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;

namespace TestTask.Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var newUser = new UserEntity
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
            };

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
