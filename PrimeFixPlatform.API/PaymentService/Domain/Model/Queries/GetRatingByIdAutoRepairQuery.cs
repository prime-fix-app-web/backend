namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

/// <summary>
///     Query to get ratings by their auto repair associated.
/// </summary>
/// <param name="IdAutoRepair">
///     The user account to filter ratings by.
/// </param>
public record GetRatingByIdAutoRepairQuery(string  IdAutoRepair);