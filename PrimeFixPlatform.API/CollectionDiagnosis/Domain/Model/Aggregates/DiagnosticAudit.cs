using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
/// <summary>
///     Audit properties for Diagnostic aggregate
/// </summary>
public partial class DiagnosticAudit :  IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}