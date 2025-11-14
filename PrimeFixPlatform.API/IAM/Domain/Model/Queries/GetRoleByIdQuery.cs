namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to get a role by its identifier.
/// </summary>
/// <param name="IdRole">
///     The identifier of the role to retrieve.
/// </param>
public record GetRoleByIdQuery(string IdRole);