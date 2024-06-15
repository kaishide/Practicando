using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderPurchase.Sale.Domain.Model.Aggregates;

public partial class Order : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}