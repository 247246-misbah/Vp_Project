using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data.Entities;
using System;

namespace Misbah_VisualProgramming_Project.Data
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {
            // Jab bhi app chaliye, agar database file physical path par exist nahi karti, 
            // to yeh tables aur local `.db` file auto-create kar dega.
            Database.EnsureCreated();
        }

        // Database Tables Mapping Registered
        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<HardwareSensor> HardwareSensors { get; set; }

        // Overriding Model Creation to seed immediate evaluable records for presentation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed Initial Menu Items for Cafe Cove Showcase
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Espresso Macchiato", Description = "Rich espresso shot with velvety milk foam layers.", Price = 420, Category = "Hot Coffee Base", StockLevel = 45 },
                new MenuItem { Id = 2, Name = "Caramel Cold Brew", Description = "Slow-steeped iced infusion with signature caramel drizzle.", Price = 550, Category = "Cold Brew Infusions", StockLevel = 30 },
                new MenuItem { Id = 3, Name = "Red Velvet Baked Muffin", Description = "Freshly baked artisan muffin filled with cream cheese.", Price = 380, Category = "Artisan Pastries", StockLevel = 15 }
            );

            // 2. Seed Default Application Security Users (Admin / Staff Roles)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "admin123", Role = "Admin", Email = "admin@cafecove.edu.pk" },
                new User { Id = 2, Username = "misbah", PasswordHash = "staff2026", Role = "Staff", Email = "misbah.staff@cafecove.edu.pk" }
            );

            // 3. Seed Digital Twin Simulated Hardware Machine Register Node
            modelBuilder.Entity<HardwareSensor>().HasData(
                new HardwareSensor { Id = 1, MachineName = "Main Italian Espresso Station #1", Temperature = 93.4, StatusBitmask = 1 }
            );
        }
    }
}