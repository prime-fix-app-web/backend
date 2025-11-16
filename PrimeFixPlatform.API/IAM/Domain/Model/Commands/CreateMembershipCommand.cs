using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to create a new membership
/// </summary>
/// <param name="IdMembership">
///     The unique identifier for the membership to be created.
/// </param>
/// <param name="MembershipDescription">
///     The description associated with the membership to be created.
/// </param>
/// <param name="Started">
///     The start date of the membership to be created.
/// </param>
/// <param name="Over">
///     The end date of the membership to be created.
/// </param>
public record CreateMembershipCommand(string IdMembership, MembershipDescription MembershipDescription, DateOnly Started, DateOnly Over);