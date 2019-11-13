using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entity;

namespace ShoppingCart.Data.Context
{
    public class ShoppingCartDbContext:DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
