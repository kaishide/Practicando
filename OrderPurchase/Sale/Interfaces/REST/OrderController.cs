using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using OrderPurchase.Sale.Domain.Model.Queries;
using OrderPurchase.Sale.Domain.Model.ValueObjects;
using OrderPurchase.Sale.Domain.Services;
using OrderPurchase.Sale.Interfaces.REST.Resources;
using OrderPurchase.Sale.Interfaces.REST.Transform;

namespace OrderPurchase.Sale.Interfaces.REST;

[ApiController]
[Route("api/v1/purchase-orders")]
[Produces(MediaTypeNames.Application.Json)]

public class OrderController(IOrderCommandService orderCommandService, IOrderQueryService orderQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        if (!Enum.IsDefined(typeof(EFabric), resource.FabricId))
        {
            return BadRequest(new { message = "Invalid Fabric Id" });
        }

        var order = await orderQueryService.Handle(
            new GetOrderByCustomerAndFabricIdQuery(resource.Customer, resource.FabricId));
        if (order != null)
        {
            return BadRequest(new { message = "Order with the same Customer and Fabric Id already exist" });
        }

        var orderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);

        var newOrder = await orderCommandService.Handle(orderCommand);

        if (newOrder == null) return BadRequest(new { message = " failed to create new order" });

        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(newOrder);

        return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, orderResource);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await orderQueryService.Handle(new GetOrderByIdQuery(id));

        if (order == null)
        {
            return NotFound();
        }

        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);

        return Ok(orderResource);
    }
    
    
}