using Microsoft.EntityFrameworkCore;
using FinanceAppWsei.Models;

namespace FinanceAppWsei.Context
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
