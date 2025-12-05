using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Represents membership behavior
/// </summary>
public interface IMembership
{
    /// <summary>
    ///     Updates the membership entity with data from an UpdateMembershipCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing data to update a Membership
    /// </param>
    void UpdateMembership(UpdateMembershipCommand command);
}