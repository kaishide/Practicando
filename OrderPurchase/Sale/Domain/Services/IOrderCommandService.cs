using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Domain.Model.Commands;

namespace OrderPurchase.Sale.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
}