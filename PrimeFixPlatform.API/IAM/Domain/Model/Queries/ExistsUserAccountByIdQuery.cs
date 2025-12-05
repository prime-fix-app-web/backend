namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to check if a user account exists by its ID
/// </summary>
/// <param name="UserAccountId">
///     The user account ID to check
/// </param>
public record ExistsUserAccountByIdQuery(int UserAccountId);