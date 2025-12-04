using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

public interface IServiceQueryService
{
    /// <summary>
    ///     Handles the retrieval of all services
    /// </summary>
    /// <param name="query">
    ///  The query object containing paraments for retrieving all services
    /// </param>
    Task<IEnumerable<Service>> Handle(GetAllServicesQuery query);
    
    /// <summary>
    ///     Handle get service by id
    /// </summary>
    /// <param name="query">
    ///     The <see cref="GetServiceByIdQuery"/> query
    /// </param>
    /// <returns>
    ///     A <see cref="Service"/>> object or null if not  found
    /// </returns>
    Task<Service?> Handle(GetServiceByIdQuery query);

}