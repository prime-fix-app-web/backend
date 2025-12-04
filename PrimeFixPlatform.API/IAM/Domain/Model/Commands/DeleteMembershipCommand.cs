namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to delete a membership
/// </summary>
/// <param name="MembershipId">
///     The unique identifier for the membership to be deleted.
/// </param>
public record DeleteMembershipCommand(int MembershipId);