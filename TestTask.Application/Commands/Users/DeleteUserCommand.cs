using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;

namespace TestTask.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<BaseResponse<DeleteUserResponse>>
    {
        public int UserId { get; set; }
    }
}
