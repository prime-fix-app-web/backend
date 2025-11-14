using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     Membership aggregate root entity
/// </summary>
public partial class Membership
{
    /// <summary>
    ///     Constructor for the Membership aggregate root entity.
    /// </summary>
    /// <param name="idMembership">
    ///     The unique identifier for the membership.
    /// </param>
    /// <param name="membershipDescription">
    ///     The description associated with the membership.
    /// </param>
    /// <param name="started">
    ///     The start date of the membership.
    /// </param>
    /// <param name="over">
    ///     The end date of the membership.
    /// </param>
    public Membership(string idMembership, MembershipDescription membershipDescription,
        DateTime started, DateTime over)
    {
        IdMembership = idMembership;
        MembershipDescription = membershipDescription;
        Started = started;
        Over = over;
    }
    
    public string IdMembership { get; private set;  }
    public MembershipDescription MembershipDescription { get; private set; }
    
    public DateTime Started { get; private set; }
    
    public DateTime Over { get; private set; }
}