using OrderPurchase.Sale.Domain.Model.ValueObjects;

namespace OrderPurchase.Sale.Interfaces.REST.Resources;

public record OrderResource(int Id,string Customer, EFabric FabricId,string City,string ResumeUrl, int Quantity)
{
    
}