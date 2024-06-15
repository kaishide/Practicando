using OrderPurchase.Sale.Domain.Model.ValueObjects;

namespace OrderPurchase.Sale.Interfaces.REST.Resources;

public record CreateOrderResource(string Customer, EFabric FabricId,string City,string ResumeUrl, int Quantity);