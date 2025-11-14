using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

public partial class Membership
{
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