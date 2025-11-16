using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents the contract for membership query services.
/// </summary>
public interface IMembershipQueryService
{
    /// <summary>
    ///     Handles the retrieval of all memberships.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving all memberships.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable collection of Membership entities.
    /// </returns>
    Task<IEnumerable<Membership>> Handle(GetAllMembershipsQuery query);
    
    /// <summary>
    ///     Handles the retrieval of a membership by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the membership to be retrieved.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the Membership entity if found; otherwise, null.
    /// </returns>
    Task<Membership?> Handle(GetMembershipByIdQuery query);
}