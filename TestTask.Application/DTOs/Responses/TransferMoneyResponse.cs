using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.DTOs.Responses
{
    public class TransferMoneyResponse
    {
        public int SenderId { get; init; }
        public int ReceiverId { get; init; }
        public decimal Amount { get; init; }
    }
}
