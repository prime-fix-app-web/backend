using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
/// Represents the contract for diagnostic command operations
/// </summary>
public interface IDiagnosticCommandService
{
    /// <summary>
    ///     Handles the creation of a new diagnostic
    /// </summary>
    Task<Diagnostic?> Handle(CreateDiagnosisCommand command);
    
    /// <summary>
    ///     Handles the update of an existing diagnosis
    /// </summary>
    /// <param name="command">
    ///     The command containing diagnosis update details
    /// </param>
    Task<Diagnostic?> Handle(UpdateDiagnosisCommand command);
    
    
    /// <summary>
    ///     Handles the deletion of a diagnosis
    /// </summary>
    /// <param name="command">
    ///     The command containing diagnosis deletion details
    /// </param>
    Task<Diagnostic?> Handle(DeleteDiagnosisCommand command);
}