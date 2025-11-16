namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to update an existing User Account
/// </summary>
/// <param name="IdUserAccount">
///     The unique identifier for the user account to be updated
/// </param>
/// <param name="Username">
///     The new username for the user account to be updated
/// </param>
/// <param name="Email">
///     The new email for the user account to be updated
/// </param>
/// <param name="IdRole">
///     The new role identifier associated with the user account to be updated
/// </param>
/// <param name="IdUser">
///     The new user identifier associated with the user account to be updated
/// </param>
/// <param name="Password">
///     The new password for the user account to be updated
/// </param>
/// <param name="IsNew">
///     Flag indicating whether the user account is new or existing
/// </param>
public record UpdateUserAccountCommand(string IdUserAccount, string Username, string Email, string IdRole, string IdUser, string Password, bool IsNew);