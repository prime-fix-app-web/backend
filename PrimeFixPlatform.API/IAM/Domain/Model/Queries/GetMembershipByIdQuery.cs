namespace PrimeFixPlatform.API.Iam.Domain.Model.Queries;

/// <summary>
///     Query to get a membership by its identifier.
/// </summary>
/// <param name="MembershipId">
///     The identifier of the membership to retrieve.
/// </param>
public record GetMembershipByIdQuery(int MembershipId);