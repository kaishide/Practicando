using OrderPurchase.Shared.Domain.Repositories;
using OrderPurchase.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace OrderPurchase.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}