using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.DTOs.Responses;

namespace TestTask.Application.Commands.MoneyTransfers
{
    public record TransferMoneyCommand : IRequest<BaseResponse<TransferMoneyResponse>>
    {
        public int SenderId { get; init; }
        public int ReceiverId { get; init; }
        public decimal Amount { get; init; }
    }
}
