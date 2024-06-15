using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Domain.Model.Queries;

namespace OrderPurchase.Sale.Domain.Services;

public interface IOrderQueryService
{
    Task<Order?> Handle(GetOrderByCustomerAndFabricIdQuery query);
    Task<Order?> Handle(GetOrderByIdQuery query);
}