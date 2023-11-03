using APIExpenseShare.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserAccountDetail> UserAccountDetails { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<UserNotificationDetail> UserNotificationDetails { get; set; }
}
