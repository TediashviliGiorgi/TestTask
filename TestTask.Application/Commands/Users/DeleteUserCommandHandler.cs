using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;
using TestTask.Domain.Interfaces;

namespace TestTask.Application.Commands.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseResponse<DeleteUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<DeleteUserResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

                if (user == null)
                {
                    return new BaseResponse<DeleteUserResponse>(false, "User not found.", null);
                }

                await _unitOfWork.UserRepository.RemoveAsync(request.UserId);
                await _unitOfWork.SaveChangesAsync();

                var response = new DeleteUserResponse
                {
                    UserId = request.UserId
                };

                return new BaseResponse<DeleteUserResponse>(true, "User deleted successfully.", response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return new BaseResponse<DeleteUserResponse>(false, ex.Message, null);
            }
        }
    }
}
