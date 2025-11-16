namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to delete a membership
/// </summary>
/// <param name="IdMembership">
///     The unique identifier for the membership to be deleted.
/// </param>
public record DeleteMembershipCommand(string IdMembership);