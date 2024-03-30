using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;

namespace TestTask.Application.Commands.Users
{
    public record CreateUserCommand : IRequest<BaseResponse<CreateUserResponse>>
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
