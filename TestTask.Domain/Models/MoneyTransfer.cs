using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Models
{
    public class MoneyTransfer
    {
        public int Id { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }

        private MoneyTransfer() { }

        public static MoneyTransfer Create(int senderId, int receiverId, decimal amount)
        {
            if (senderId <= 0)
            {
                throw new ArgumentException("SenderId is required and must be greater than zero.", nameof(senderId));
            }

            if (receiverId <= 0)
            {
                throw new ArgumentException("ReceiverId is required and must be greater than zero.", nameof(receiverId));
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount is required and must be greater than zero.", nameof(amount));
            }

            if (senderId == receiverId)
            {
                throw new ArgumentException("Sender and receiver cannot be the same.");
            }

            return new MoneyTransfer
            {
                SenderUserId = senderId,
                ReceiverUserId = receiverId,
                Amount = amount,
                TransferDate = DateTime.UtcNow
            };
        }
    }
}
