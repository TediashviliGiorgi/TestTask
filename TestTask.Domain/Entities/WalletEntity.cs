using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Entities
{
    public class WalletEntity
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        public UserEntity User { get; set; }
    }
}
