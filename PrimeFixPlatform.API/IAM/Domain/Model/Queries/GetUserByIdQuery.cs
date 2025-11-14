namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to retrieve a user by their unique identifier.
/// </summary>
/// <param name="IdUser">
///     The unique identifier of the user to be retrieved.
/// </param>
public record GetUserByIdQuery(string IdUser);