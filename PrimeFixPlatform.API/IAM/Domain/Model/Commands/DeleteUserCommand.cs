namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to delete a user
/// </summary>
/// <param name="IdUser">
///     The ID of the user to be deleted
/// </param>
public record DeleteUserCommand(string IdUser);