using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.QueryServices;

/// <summary>
///     Query service for service aggregate 
/// </summary>
/// <param name="serviceRepository">
///     The service repository
/// </param>
public class ServiceQueryService(IServiceRepository serviceRepository): IServiceQueryService
{
    /// <summary>
    ///     Handles the query to get all services
    /// </summary>
    /// <param name="query">
    ///     The query to get all services
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a enumerable of services.
    /// </returns>
    public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery query)
    {
        return await serviceRepository.ListAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<Service?> Handle(GetServiceByIdQuery query)
    {
        return await serviceRepository.FindByIdAsync(query.ServiceId);
    }
}