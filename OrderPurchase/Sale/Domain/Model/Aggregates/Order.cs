using OrderPurchase.Sale.Domain.Model.Commands;
using OrderPurchase.Sale.Domain.Model.ValueObjects;

namespace OrderPurchase.Sale.Domain.Model.Aggregates;

public partial class Order
{
    public int Id {get; set;}
    public string Customer {get; private set;}
    public EFabric FabricId {get; private set;}
    public string City {get; private set;}
    public string ResumeUrl  {get; private set;}
    public int Quantity {get; private set;}

    public Order()
    {
        Customer = "";
        FabricId = EFabric.Lyocell;
        City = "";
        ResumeUrl = "";
        Quantity = 0;
    }

    public Order(string customer, EFabric fabricId, string city, string resumeUrl, int quantity)
    {
        Customer = customer;
        FabricId = fabricId;
        City = city;
        ResumeUrl = resumeUrl;
        Quantity = quantity;
    }

    public Order(CreateOrderCommand command)
    {
        Customer = command.Customer;
        FabricId = command.FabricId;
        City = command.City;
        ResumeUrl = command.ResumeUrl;
        Quantity = command.Quantity;

    }
    
}