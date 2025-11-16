namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;

/// <summary>
///     Query to get payments by their user account associated.
/// </summary>
/// <param name="IdUserAccount">
///     The user account to filter payments by.
/// </param>
public record GetPaymentByIdUserAccountQuery(string IdUserAccount);