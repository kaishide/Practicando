using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Domain.Model.ValueObjects;
using OrderPurchase.Shared.Domain.Repositories;

namespace OrderPurchase.Sale.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order?> FindOrderByCustomerAndFabricIdAsync(string customer, EFabric fabricId);

    Task<Order?> FindOrderByIdAsync(int id);
}