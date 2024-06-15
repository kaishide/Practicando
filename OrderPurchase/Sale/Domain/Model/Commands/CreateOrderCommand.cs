using OrderPurchase.Sale.Domain.Model.ValueObjects;

namespace OrderPurchase.Sale.Domain.Model.Commands;

public record CreateOrderCommand(string Customer, EFabric FabricId,string City,string ResumeUrl, int Quantity);