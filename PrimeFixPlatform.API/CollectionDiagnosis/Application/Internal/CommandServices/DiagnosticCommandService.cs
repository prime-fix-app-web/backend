using Cortex.Mediator;
using Cortex.Mediator.Infrastructure;
using PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.OutboundServices.ACL;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using IUnitOfWork = PrimeFixPlatform.API.Shared.Domain.Repositories.IUnitOfWork;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.CommandServices;

/// <summary>
///     Command service for Diagnostic aggregate
/// </summary>
/// <param name="diagnosticRepository">
///     The diagnostic repository
/// </param>
/// <param name="externalMaintenanceTrackingServiceFromCollectionDiagnosis">
///     The external maintenance tracking service from collection diagnosis
/// </param>
/// <param name="unitOfWork">
///     Unit of Work
/// </param>
/// <param name="mediator">
///     The mediator
/// </param>
public class DiagnosticCommandService(
    IDiagnosticRepository diagnosticRepository, 
    IExternalMaintenanceTrackingServiceFromCollectionDiagnosis externalMaintenanceTrackingServiceFromCollectionDiagnosis,
    IUnitOfWork unitOfWork,
    IMediator mediator):
    IDiagnosticCommandService
{
    /// <summary>
    ///     Handles the command to create a new Diagnostic 
    /// </summary>
    /// <param name="command">
    ///     The command to create a new diagnostic
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created diagnostic.
    /// </returns>
    public async Task<Diagnostic?> Handle(CreateDiagnosisCommand command)
    {
        var diagnosis = new Diagnostic(command);
        await diagnosticRepository.AddAsync(diagnosis);
        await unitOfWork.CompleteAsync();
        
        // Validate that the vehicle exists in the external maintenance tracking system
        if (!await externalMaintenanceTrackingServiceFromCollectionDiagnosis.ExitsVehicleByIdAsync(command.VehicleId))
        {
            throw new NotFoundArgumentException("Vehicle not found in Maintenance Tracking Service");
        }
        
        // Publish the domain event after the diagnostic is created
        await mediator.PublishAsync(new DiagnosticRegisteredEvent(command.VehicleId, command.Diagnosis));
        
        return diagnosis;
    }
    
    /// <summary>
    ///     Handles the command to update an existing diagnostic
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing diagnostic 
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contain the updated diagnostic.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the diagnostic with the specified Diagnostic ID was not found.
    /// </exception>
    public async Task<Diagnostic?> Handle(UpdateDiagnosisCommand command)
    {
        var diagnosisId = command.DiagnosisId;
        var diagnosticToUpdate = await diagnosticRepository.FindById(diagnosisId);

        if (diagnosticToUpdate == null)
        {
            throw new NotFoundArgumentException("Diagnosis not found");
        }
        
        // Validate that the vehicle exists in the external maintenance tracking system
        if (!await externalMaintenanceTrackingServiceFromCollectionDiagnosis.ExitsVehicleByIdAsync(command.VehicleId.Id))
        {
            throw new NotFoundArgumentException("Vehicle not found in Maintenance Tracking Service");
        }

        diagnosticToUpdate.UpdateDiagnosis(command);
    
        diagnosticRepository.Update(diagnosticToUpdate);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the diagnostic is created
        await mediator.PublishAsync(new DiagnosticRegisteredEvent(command.VehicleId.Id, command.Diagnosis));

        return diagnosticToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete a diagnostic
    /// </summary>
    /// <param name="command">
    ///     The command to delete a diagnostic
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the deleted diagnostic
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user with the specified diagnosticID was not found
    /// </exception>
    public async Task<Diagnostic?> Handle(DeleteDiagnosisCommand command)
    {
        var diagnostic = await diagnosticRepository.FindById(command.DiagnosisId);
        if (diagnostic == null)
            throw new NotFoundArgumentException("Diagnostic not found");
        diagnosticRepository.Remove(diagnostic);
        await unitOfWork.CompleteAsync();
        return diagnostic;
    }
}