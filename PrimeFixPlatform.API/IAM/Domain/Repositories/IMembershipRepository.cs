using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.Iam.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Membership entities.
/// </summary>
public interface IMembershipRepository : IBaseRepository<Membership>
{
    /// <summary>
    ///     Checks if a membership exists by its unique identifier.
    /// </summary>
    /// <param name="idMembership">
    ///     The unique identifier of the membership.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a membership with the specified ID exists.
    /// </returns>
    Task<bool> ExistsByIdMembership(string idMembership);
    
    /// <summary>
    ///     Checks if a membership exists by its membership description.
    /// </summary>
    /// <param name="membershipDescription">
    ///     The membership description to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a membership with the specified membership description exists.
    /// </returns>
    Task<bool> ExistsByMembershipDescription(MembershipDescription membershipDescription);
    
    /// <summary>
    ///     Checks if a membership exists by its membership description, excluding a specific membership by its ID.
    /// </summary>
    /// <param name="membershipDescription">
    ///     The membership description to check.
    /// </param>
    /// <param name="idMembership">
    ///     The unique identifier of the membership to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a membership with the specified membership description exists,
    ///     excluding the membership with the specified ID.
    /// </returns>
    Task<bool> ExistsByMembershipDescriptionAndIdMembershipIsNot(MembershipDescription membershipDescription, string idMembership);
}