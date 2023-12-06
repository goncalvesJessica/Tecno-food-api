using Microsoft.EntityFrameworkCore;
using TecnoFood.Models;

namespace TecnoFood.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> opts)
        : base(opts)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
}
