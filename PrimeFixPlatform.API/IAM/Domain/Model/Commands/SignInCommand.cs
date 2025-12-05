namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to sign in a user
/// </summary>
/// <param name="Username">
///     The username of the user attempting to sign in
/// </param>
/// <param name="Password">
///     The password of the user attempting to sign in
/// </param>
public record SignInCommand(string Username, string Password);