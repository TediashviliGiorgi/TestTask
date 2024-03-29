using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;

namespace TestTask.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WalletEntity> Wallets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<WalletEntity>(w => w.UserId);
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
