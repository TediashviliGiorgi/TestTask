using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Services.Hashing
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPassword;
        }
    }
}
