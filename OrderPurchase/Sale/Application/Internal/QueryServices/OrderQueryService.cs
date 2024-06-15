using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Domain.Model.Queries;
using OrderPurchase.Sale.Domain.Repositories;
using OrderPurchase.Sale.Domain.Services;

namespace OrderPurchase.Sale.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository): IOrderQueryService
{
    public async Task<Order?> Handle(GetOrderByCustomerAndFabricIdQuery query)
    {
        return await orderRepository.FindOrderByCustomerAndFabricIdAsync(query.customer, query.fabricId);
    }

    public async Task<Order?> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindOrderByIdAsync(query.Id);
        
    }
}