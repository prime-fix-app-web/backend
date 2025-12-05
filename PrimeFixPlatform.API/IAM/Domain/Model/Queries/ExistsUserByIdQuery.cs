namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to check if a user exists by its ID
/// </summary>
/// <param name="UserId">
///    The user ID to check
/// </param>
public record ExistsUserByIdQuery(int UserId);