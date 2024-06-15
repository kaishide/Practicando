using OrderPurchase.Sale.Domain.Model.Commands;
using OrderPurchase.Sale.Interfaces.REST.Resources;

namespace OrderPurchase.Sale.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(resource.Customer, resource.FabricId, resource.City, resource.ResumeUrl,
            resource.Quantity);
    }
}