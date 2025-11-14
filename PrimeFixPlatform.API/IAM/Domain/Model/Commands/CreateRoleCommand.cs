using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///    Command to create a new role
/// </summary>
/// <param name="IdRole">
///     The ID of the role to be created
/// </param>
/// <param name="RoleInformation">
///     The information of the role to be created
/// </param>
public record CreateRoleCommand(string IdRole, RoleInformation RoleInformation);