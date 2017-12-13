using Microsoft.EntityFrameworkCore;
 
namespace BankAccount.Models
{
    public class AccountContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
    }
}