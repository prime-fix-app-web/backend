namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to create a new User Account
/// </summary>
/// <param name="Username">
///     The username for the user account to be created
/// </param>
/// <param name="Email">
///     The email address associated with the user account to be created
/// </param>
/// <param name="RoleId">
///     The unique identifier for the role assigned to the user account to be created
/// </param>
/// <param name="UserId">
///     The unique identifier for the user associated with the account to be created
/// </param>
/// <param name="Password">
///     The password for the user account to be created
/// </param>
/// <param name="IsNew">
///     Flag indicating whether the user account is new
/// </param>
public record CreateUserAccountCommand( string Username, string Email, int RoleId, int UserId, string Password, bool IsNew);