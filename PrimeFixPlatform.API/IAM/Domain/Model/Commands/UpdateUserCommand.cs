namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to update an existing user
/// </summary>
/// <param name="UserId">
///     The ID of the user to be updated
/// </param>
/// <param name="Name">
///     The name of the user to be updated
/// </param>
/// <param name="LastName">
///     The last name of the user to be updated
/// </param>
/// <param name="Dni">
///     The national identification number of the user to be updated
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the user to be updated
/// </param>
/// <param name="LocationId">
///     The location ID of the user to be updated
/// </param>
public record UpdateUserCommand(int UserId, string Name, string LastName, string Dni, string PhoneNumber, int LocationId);