using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.QueryServices;

/// <summary>
///      Query service for diagnostic aggregate
/// </summary>
/// <param name="diagnosticRepository">
///     The diagnostic repository
/// </param>
public class DiagnosticQueryService(IDiagnosticRepository diagnosticRepository): IDiagnosticQueryService
{
    /// <summary>
    ///     Handles the query to get all diagnostic
    /// </summary>
    /// <param name="query">
    ///     The query to get all diagnostic
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a enumerable of diagnostic
    /// </returns>
    public async Task<IEnumerable<Diagnostic>> Handle(GetAllDiagnosticsQuery query)
    {
        return await diagnosticRepository.ListAsync();
    }
    
    
    /// <summary>
    ///     Handles the query to get a diagnostic by the VehicleID
    /// </summary>
    /// <param name="query">
    ///     The query to get diagnostic by the VehicleID
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operations. The task result contains the diagnostic if found; otherwise, null.  
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that a diagnostic with the specified identifier was no found
    /// </exception>
    public async Task<Diagnostic?> Handle(GetDiagnosticsByVehicleIdQuery query)
    {
        return await diagnosticRepository.FindByVehicleId(new VehicleId(query.VehicleId)) 
               ?? throw new NotFoundArgumentException("Diagnostic with the Vehicle ID" + query.VehicleId +
                                                      "was not found");
    }

    public async Task<Diagnostic?> Handle(GetDiagnosticByIdQuery query)
    {
        return await diagnosticRepository.FindByIdAsync(query.DiagnosticId);
    }

    public async Task<Diagnostic?> Handle(GetDiagnosticsByExpectedVisitQuery query)
    {
        return await diagnosticRepository.FindByExpectedId(query.ExpectedVisitId);
    }
}