using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;

/// <summary>
///     Audit fields for Rating entity
/// </summary>
public partial class RatingAudit: IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}