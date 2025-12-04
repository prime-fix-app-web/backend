using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///    Command to create a new role
/// </summary>
/// <param name="RoleInformation">
///     The information of the role to be created
/// </param>
public record CreateRoleCommand( RoleInformation RoleInformation);