using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Models;
using TestTask.Domain.Interfaces;

namespace TestTask.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _db.Users
                .Include(u => u.Wallet) // Include the WalletEntity
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task RemoveAsync(int UserId)
        {
            var user = await _db.Users.FindAsync(UserId);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }
    }
}
