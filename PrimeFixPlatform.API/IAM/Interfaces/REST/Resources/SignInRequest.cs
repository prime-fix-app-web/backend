namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Request model for user sign-in.
/// </summary>
/// <param name="Username">
///     The username of the user attempting to sign in.
/// </param>
/// <param name="Password">
///     The password of the user attempting to sign in.
/// </param>
public record SignInRequest(
    string Username,
    string Password
);