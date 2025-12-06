using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for Diagnostic related transformations
/// </summary>
public static class DiagnosticAssembler
{
    /// <summary>
    ///     Converts a CreateDiagnosticRequest to a CreateDiagnosisCommand
    /// </summary>
    /// <param name="request">
    ///     The CreateDiagnosticRequest to be converted
    /// </param>
    /// <returns>
    ///     The corresponding CreateDiagnosisCommand
    /// </returns>
    public static CreateDiagnosisCommand ToCommandFromRequest(CreateDiagnosticRequest request)
    {
        return new CreateDiagnosisCommand(request.Price, request.VehicleId, request.Diagnosis);
    }

    /// <summary>
    ///     Converts an UpdateDiagnosticRequest to an UpdateDiagnosisCommand
    /// </summary>
    /// <param name="request">
    ///     The UpdateDiagnosticRequest to be converted
    /// </param>
    /// <param name="diagnosisId">
    ///     The ID of the diagnosis to be updated
    /// </param>
    /// <returns>
    ///     The corresponding UpdateDiagnosisCommand
    /// </returns>
    public static UpdateDiagnosisCommand ToCommandFromRequest(UpdateDiagnosticRequest request, int diagnosisId)
    {
        return new UpdateDiagnosisCommand(diagnosisId, request.Price, new VehicleId(request.VehicleId.Id), request.Diagnosis);
    }


    /// <summary>
    ///     Converts a Diagnostic entity to a DiagnosticResponse
    /// </summary>
    /// <param name="entity">
    ///     The Diagnostic entity to be converted
    /// </param>
    /// <returns>
    ///     The corresponding DiagnosticResponse
    /// </returns>
    public static DiagnosticResponse ToResponseFromEntity(Diagnostic entity)
    {
        return new DiagnosticResponse(entity.Id,entity.Price,entity.VehicleId.Id, entity.Diagnosis);
    }
}