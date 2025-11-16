namespace PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Represents information about a role.
/// </summary>
/// <param name="Name">
///     The name of the role.
/// </param>
/// <param name="Description">
///     The description of the role.
/// </param>
public record RoleInformation(string Name, string Description);