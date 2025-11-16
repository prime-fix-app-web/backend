using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.QueryServices;

/// <summary>
///     Query service for memberships
/// </summary>
/// <param name="membershipRepository">
///     The membership repository
/// </param>
public class MembershipQueryService(IMembershipRepository membershipRepository)
: IMembershipQueryService
{
    /// <summary>
    ///     Handles the query to get all memberships
    /// </summary>
    /// <param name="query">
    ///     The query to get all memberships
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of memberships.
    /// </returns>
    public async Task<IEnumerable<Membership>> Handle(GetAllMembershipsQuery query)
    {
        return await membershipRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the query to get a membership by its unique identifier
    /// </summary>
    /// <param name="query">
    ///     The query to get a membership by its unique identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the membership if found; otherwise, null.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a membership with the specified identifier was not found.
    /// </exception>
    public async Task<Membership?> Handle(GetMembershipByIdQuery query)
    {
        return await membershipRepository.FindByIdAsync(query.IdMembership)
            ?? throw new NotFoundIdException("Membership with the id " + query.IdMembership + " was not found.");
    }
}