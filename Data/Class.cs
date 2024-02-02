using Microsoft.EntityFrameworkCore;
using Storeii.Models;

namespace Storeii.Data
{
    public class StoreiiContext : DbContext
    {
        public StoreiiContext(DbContextOptions<StoreiiContext> options) : base(options)
        {
        }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Storeii.Models.CartItem> CartItem { get; set; }
        public DbSet<Storeii.Models.Customer> Customer { get; set; }
        public DbSet<Storeii.Models.Location> Location { get; set; }
        public DbSet<Storeii.Models.OrderItem> OrderItems { get; set; }
        public DbSet<Storeii.Models.Product> Product { get; set; }
        public DbSet<Storeii.Models.Supplier> Supplier { get; set; }
    }
}