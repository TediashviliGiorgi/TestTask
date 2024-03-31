using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        public User User { get; set; }

        private Wallet() { }

        public static Wallet Create(int userId, decimal balance)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("UserId must be greater than zero.", nameof(userId));
            }

            if (balance < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(balance));
            }

            return new Wallet
            {
                UserId = userId,
                Balance = balance
            };
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));
            }

            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }

            Balance -= amount;
        }
    }
}
