using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

/// <summary>
///     Represents the contract for a service command services
/// </summary>
public interface IServiceCommandService
{
    /// <summary>
    /// Handles the creation of a new services
    /// </summary>
    Task<Service?> Handle(CreateServiceCommand command);
    
    /// <summary>
    ///     Handles the update of an existing servcies
    /// </summary>
    /// <param name="command">
    ///     The command containing services update details
    /// </param>
    Task<Service?> Handle(UpdateServiceCommand command);
    
    /// <summary>
    ///     Handles the deletion of a services
    /// </summary>
    /// <param name="command">
    ///     The command containing services deletion details
    /// </param>
    Task<Service?> Handle(DeleteServiceCommand command);
}