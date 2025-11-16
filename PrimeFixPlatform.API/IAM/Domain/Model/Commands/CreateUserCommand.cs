namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to create a new user
/// </summary>
/// <param name="IdUser">
///     The ID of the user to be created
/// </param>
/// <param name="Name">
///     The name of the user to be created
/// </param>
/// <param name="LastName">
///     The last name of the user to be created
/// </param>
/// <param name="Dni">
///     The national identification number of the user to be created
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the user to be created
/// </param>
/// <param name="IdLocation">
///     The location ID of the user to be created
/// </param>
public record CreateUserCommand(string IdUser, string Name, string LastName, string Dni, string PhoneNumber, string IdLocation);