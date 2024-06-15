using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using OrderPurchase.Sale.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using OrderPurchase.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace OrderPurchase.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration

        builder.Entity<Order>().HasKey(c => c.Id);
        
        builder.Entity<Order>().Property(c => c.Customer).IsRequired();
        
        builder.Entity<Order>().Property(c => c.FabricId).IsRequired();

        builder.Entity<Order>().Property(c => c.City).IsRequired();
        
        builder.Entity<Order>().Property(c => c.ResumeUrl).IsRequired();
        
        builder.Entity<Order>().Property(c => c.Quantity).IsRequired();

        
        
        // Apply SnakeCase Naming Convention
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}