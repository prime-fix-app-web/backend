using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to update an existing role
/// </summary>
/// <param name="RoleId">
///     The ID of the role to be updated
/// </param>
/// <param name="RoleInformation">
///     The new information of the role to be updated
/// </param>
public record UpdateRoleCommand(int RoleId, RoleInformation RoleInformation);