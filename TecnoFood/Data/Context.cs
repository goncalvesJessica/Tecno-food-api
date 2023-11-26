using Microsoft.EntityFrameworkCore;
using TecnoFood.Models;

namespace TecnoFood.Data;

public class Context: DbContext
{
    public Context(DbContextOptions <Context> opts)
        : base(opts)
    {

    }

    public DbSet<Product> Products { get;set; }
    public DbSet<User> Users { get;set; }
}
