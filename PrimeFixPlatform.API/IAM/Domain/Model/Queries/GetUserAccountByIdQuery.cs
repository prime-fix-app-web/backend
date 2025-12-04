namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to retrieve a user account by its unique identifier.
/// </summary>
/// <param name="UserAccountId">
///     The unique identifier of the user account to be retrieved.
/// </param>
public record GetUserAccountByIdQuery(int UserAccountId);