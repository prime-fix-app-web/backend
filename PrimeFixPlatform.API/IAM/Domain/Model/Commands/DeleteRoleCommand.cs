namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to delete a role by its identifier.
/// </summary>
/// <param name="IdRole">
///     The identifier of the role to be deleted.
/// </param>
public record DeleteRoleCommand(string IdRole);