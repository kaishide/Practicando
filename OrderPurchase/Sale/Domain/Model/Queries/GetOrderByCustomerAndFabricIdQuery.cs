using OrderPurchase.Sale.Domain.Model.ValueObjects;

namespace OrderPurchase.Sale.Domain.Model.Queries;

public record GetOrderByCustomerAndFabricIdQuery(string customer, EFabric fabricId);