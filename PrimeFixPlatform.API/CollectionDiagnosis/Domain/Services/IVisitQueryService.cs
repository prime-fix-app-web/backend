using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
///     Represents the contract for a visit query services
/// </summary>
public interface IVisitQueryService
{
    /// <summary>
    ///     Handles the retrieval of all visit
    /// </summary>
    Task<IEnumerable<Visit>> Handle(GetAllVisitsQuery query);

    /// <summary>
    ///     Handles tre retrieval of a visit by its unique identifier
    /// </summary>
    Task<Visit?> Handle(GetVisitsByAutoRepairIdQuery query);
    
    /// <summary>
    ///     Handle the visit by id
    /// </summary>
    Task<Visit?> Handle(GetVisitByIdQuery query);
    
    /// <summary>
    ///     Handle the retrieval of a visit by vehicle ID
    /// </summary>
    Task<Visit?> Handle(GetVisitByVehicleIdQuery query);
    
    /// <summary>
    ///     Handle the retrieval of a visit by service ID
    /// </summary>
    Task<Visit?> Handle(GetVisitByServiceIdQuery query);
}