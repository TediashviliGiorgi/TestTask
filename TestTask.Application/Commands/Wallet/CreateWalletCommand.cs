using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs;
using TestTask.Application.DTOs.Responses;

namespace TestTask.Application.Commands.Wallet
{
    public record CreateWalletCommand : IRequest<BaseResponse<CreateWalletResponse>>
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
