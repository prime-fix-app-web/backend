using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Membership entities.
/// </summary>
/// <param name="context"></param>
public class MembershipRepository(AppDbContext context)
: BaseRepository<Membership>(context), IMembershipRepository
{
    /// <summary>
    ///     Checks if a Membership exists by its unique identifier.
    /// </summary>
    /// <param name="membershipId">
    ///     The unique identifier of the Membership.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Membership with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByMembershipId(int membershipId)
    {
        return await Context.Set<Membership>().AnyAsync(membership => membership.Id == membershipId);
    }

    /// <summary>
    ///     Checks if a Membership exists by its MembershipDescription.
    /// </summary>
    /// <param name="membershipDescription">
    ///     The description of the Membership.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Membership with the specified MembershipDescription exists.
    /// </returns>
    public async Task<bool> ExistsByMembershipDescription(MembershipDescription membershipDescription)
    {
        return await Context.Set<Membership>().AnyAsync(membership => 
            membership.MembershipDescription.Description == membershipDescription.Description);
    }

    /// <summary>
    ///     Checks if a Membership exists by its MembershipDescription, excluding a specific membership by ID.
    /// </summary>
    /// <param name="membershipDescription">
    ///     The description of the Membership.
    /// </param>
    /// <param name="membershipId"></param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Membership with the specified MembershipDescription exists,
    ///     excluding the Membership with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByMembershipDescriptionAndMembershipIdIsNot(MembershipDescription membershipDescription,
        int membershipId)
    {
        return await Context.Set<Membership>().AnyAsync(membership => 
            membership.MembershipDescription.Description == membershipDescription.Description &&
            membership.Id != membershipId);
    }
}