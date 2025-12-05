using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     The query to get a role by its name
/// </summary>
/// <param name="Name">
///     The name of the role to retrieve
/// </param>
public record GetRoleByNameQuery(ERole Name);