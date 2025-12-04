namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to create a new user
/// </summary>
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
/// <param name="LocationId">
///     The location ID of the user to be created
/// </param>
public record CreateUserCommand(string Name, string LastName, string Dni, string PhoneNumber, int LocationId);