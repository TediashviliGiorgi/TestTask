using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;
using TestTask.Application.Services.Hashing;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces;

namespace TestTask.Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<CreateUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<BaseResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userWithEmail = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);

                if (userWithEmail != null)
                {
                    return new BaseResponse<CreateUserResponse>(false, "User with this email already exists.", null);
                }

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

                var response = new CreateUserResponse
                {
                    
                    Name = newUser.Name,
                    LastName = newUser.LastName,
                    Email = newUser.Email
                };

                return new BaseResponse<CreateUserResponse>(true, "User created successfully.", response);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CreateUserResponse>(false, ex.Message, null);
            }
        }
    }
}
