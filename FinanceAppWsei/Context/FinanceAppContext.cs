using Microsoft.EntityFrameworkCore;
using FinanceAppWsei.Models;

namespace FinanceAppWsei.Context
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<MoneyBox> MoneyBoxes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
