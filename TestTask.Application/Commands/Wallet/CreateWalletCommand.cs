using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Commands.Wallet
{
    public record CreateWalletCommand : IRequest<Unit>
    {
        [Required(ErrorMessage = "need specify userId to assign wallet existing user")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Balance is required.")]
        public decimal Balance { get; set; }
    }
}
