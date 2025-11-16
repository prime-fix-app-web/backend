namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to delete a user account
/// </summary>
/// <param name="IdUserAccount">
///     The identifier of the user account to be deleted
/// </param>
public record DeleteUserAccountCommand(string IdUserAccount);