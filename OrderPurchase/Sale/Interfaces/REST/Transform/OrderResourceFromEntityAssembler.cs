using OrderPurchase.Sale.Domain.Model.Aggregates;
using OrderPurchase.Sale.Interfaces.REST.Resources;

namespace OrderPurchase.Sale.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order order)
    {
        return new OrderResource(order.Id, order.Customer, order.FabricId, order.City, order.ResumeUrl, order.Quantity);
        
    }
}