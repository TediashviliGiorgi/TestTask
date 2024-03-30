using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByEmailAsync(string email);
        Task<UserEntity> GetByIdAsync(int id);
        Task AddAsync(UserEntity user);
        Task RemoveAsync(int id);
    }
}
