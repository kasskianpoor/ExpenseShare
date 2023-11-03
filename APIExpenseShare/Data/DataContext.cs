﻿using APIExpenseShare.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIExpenseShare.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }



    public DbSet<User> Users { get; set; }
    public DbSet<UserAccountDetail> UserAccountDetails { get; set; }
    public DbSet<UserNotificationDetail> UserNotificationDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>()
        //     .HasOne(p => p.UserAccountDetail)
        //     .WithOne(b => b.User)
        //     .HasForeignKey<UserAccountDetail>(p => p.UserId);
    }
}
