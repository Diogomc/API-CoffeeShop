using CoffeeShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Context;

public class AppDbContext: DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Foods>? Foods { get; set; }
}
