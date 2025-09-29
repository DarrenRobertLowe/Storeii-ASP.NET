using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Storeii.Models;
using System;

namespace Storeii.Data
{
    public class StoreiiContext : DbContext
    {
        public StoreiiContext(DbContextOptions<StoreiiContext> options) : base(options)
        {
        }

        // enable logging (FOR DEBUG ONLY!)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Driver> Driver { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Counties> Counties { get; set; }
        public DbSet<Suborder> Suborder { get; set; }
        public DbSet<Suborder_Items> Suborder_Items { get; set; }
        public DbSet<User> User { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.CustomerNavigation)
            .WithOne(c => (User)c.User)
            .HasForeignKey<User>(u => u.Customer);

            modelBuilder.Entity<User>()
            .HasOne(u => u.DriverNavigation)
            .WithOne(c => (User)c.User)
            .HasForeignKey<User>(u => u.Driver);

            modelBuilder.Entity<User>()
            .HasOne(u => u.SupplierNavigation)
            .WithOne(c => (User)c.User)
            .HasForeignKey<User>(u => u.Supplier);
        }
        
    }
}