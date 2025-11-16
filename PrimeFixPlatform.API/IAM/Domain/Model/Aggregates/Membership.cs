using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     Membership aggregate root entity
/// </summary>
public partial class Membership
{
    /// <summary>
    ///     Private constructor for ORM and serialization purposes
    /// </summary>
    private Membership() { }
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
        DateOnly started, DateOnly over)
    {
        IdMembership = idMembership;
        MembershipDescription = membershipDescription;
        Started = started;
        Over = over;
    }
    
    /// <summary>
    ///     The constructor for the Membership aggregate root entity from CreateMembershipCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a Membership
    /// </param>
    public Membership(CreateMembershipCommand command): this(
        command.IdMembership,
        command.MembershipDescription,
        command.Started,
        command.Over)
    {
    }
    
    /// <summary>
    ///     Updates the membership entity with data from an UpdateMembershipCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to update a Membership
    /// </param>
    public void UpdateMembership(UpdateMembershipCommand command)
    {
        MembershipDescription = command.MembershipDescription;
        Started = command.Started;
        Over = command.Over;
    }
    
    public string IdMembership { get; private set;  }
    public MembershipDescription MembershipDescription { get; private set; }
    
    public DateOnly Started { get; private set; }
    
    public DateOnly Over { get; private set; }
}