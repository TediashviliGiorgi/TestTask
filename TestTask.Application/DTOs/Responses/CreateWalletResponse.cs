using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.DTOs.Responses
{
    public class CreateWalletResponse
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
