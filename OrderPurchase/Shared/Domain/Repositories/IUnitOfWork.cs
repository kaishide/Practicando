namespace OrderPurchase.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}