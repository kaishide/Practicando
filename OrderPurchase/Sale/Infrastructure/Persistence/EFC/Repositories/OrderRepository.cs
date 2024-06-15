using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Domain.Model.ValueObjects;
using OrderPurchase.Sale.Domain.Repositories;
using OrderPurchase.Shared.Infrastructure.Persistence.EFC.Configuration;
using OrderPurchase.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace OrderPurchase.Sale.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<Order?> FindOrderByCustomerAndFabricIdAsync(string customer, EFabric fabricId)
    {
        return Context.Set<Order>().Where(p => p.Customer == customer && p.FabricId == fabricId).FirstOrDefault();
    }

    public async Task<Order?> FindOrderByIdAsync(int id)
    {
        return Context.Set<Order>().Where(p => p.Id == id).FirstOrDefault();
    }
    
    
}