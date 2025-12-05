namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to get a user account by user id
/// </summary>
/// <param name="UserId"></param>
public record GetUserAccountByUserIdQuery(int UserId);