using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using OrderWebAPI.Domain.Product;

namespace OrderWebAPI.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<Notification>();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(300);
        builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(100);
    }

}
