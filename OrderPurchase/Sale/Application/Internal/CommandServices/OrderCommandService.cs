using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Domain.Model.Commands;
using OrderPurchase.Sale.Domain.Repositories;
using OrderPurchase.Sale.Domain.Services;
using OrderPurchase.Shared.Domain.Repositories;

namespace OrderPurchase.Sale.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork): IOrderCommandService
{
    public async Task<Order?> Handle(CreateOrderCommand command)
    {
        var order = new Order(command);
        try
        {
            await orderRepository.AddAsync(order);
            await unitOfWork.CompleteAsync();
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating a order:{ex.Message}");
            return null;
        }
    }
}