using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
///     Represents the contract for a diagnosis query services 
/// </summary>
public interface IDiagnosticQueryService
{
    /// <summary>
    ///      Handles the retrieval of all diagnosis
    /// </summary>
    /// <param name="query">
    ///     The query object containing paraments for retrieving all diagnostic
    /// </param>
    Task<IEnumerable<Diagnostic>> Handle(GetAllDiagnosticsQuery query);

    /// <summary>
    ///     Handles the retrieval of a diagnosis by its unique identifier
    /// </summary>
    Task<Diagnostic?> Handle(GetAllDiagnosticsByVehicleIdQuery query);

}