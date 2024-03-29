using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public WalletEntity Wallet { get; set; }
    }
}
