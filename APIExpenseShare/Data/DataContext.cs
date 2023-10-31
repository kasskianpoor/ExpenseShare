using APIExpenseShare.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
