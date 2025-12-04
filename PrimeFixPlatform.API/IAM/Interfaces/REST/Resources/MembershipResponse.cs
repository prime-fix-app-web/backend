namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Response for membership information
/// </summary>
/// <param name="Description">
///     The description of the membership
/// </param>
/// <param name="Started">
///     The start date of the membership
/// </param>
/// <param name="Over">
///     The end date of the membership
/// </param>
public record MembershipResponse(
    int Id,
    string Description,
    DateOnly Started,
    DateOnly Over);