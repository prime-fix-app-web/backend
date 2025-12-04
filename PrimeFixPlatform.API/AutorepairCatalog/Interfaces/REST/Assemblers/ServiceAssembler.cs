using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;

/// <summary>
/// Assembler responsible for mapping Service REST requests into domain commands and converting Service domain entities
/// into response resources.
/// </summary>
public class ServiceAssembler
{
    /// <summary>
    /// Creates a <see cref="CreateServiceCommand"/> from a <see cref="CreateServiceRequest"/>.
    /// </summary>
    /// <param name="request">
    /// Request payload containing the information required to create a service.
    /// </param>
    /// <returns>
    /// A <see cref="CreateServiceCommand"/> ready to be dispatched to the domain layer.
    /// </returns>
    public static CreateServiceCommand ToCommandFromRequest(CreateServiceRequest request)
    {
        return new CreateServiceCommand(request.Name, request.Description);
    }

    
    /// <summary>
    /// Creates an <see cref="UpdateServiceCommand"/> from a request and the target service identifier.
    /// </summary>
    /// <param name="request">
    /// Request payload containing the updated service information.
    /// </param>
    /// <param name="serviceId">
    /// Identifier of the service that will be updated.
    /// </param>
    /// <returns>
    /// A <see cref="UpdateServiceCommand"/> ready to be dispatched to the domain layer.
    /// </returns>
    public static UpdateServiceCommand ToCommandFromRequest(UpdateServiceCommand request, int serviceId)
    {
        return new UpdateServiceCommand(serviceId,request.Name, request.Description);
    }

    /// <summary>
    /// Converts a <see cref="Service"/> domain entity to a <see cref="ServiceResponse"/>
    /// resource for REST responses.
    /// </summary>
    /// <param name="entity">
    /// Domain Service entity to convert.
    /// </param>
    /// <returns>
    /// A <see cref="ServiceResponse"/> representing the service data for API clients.
    /// </returns>
    public static ServiceResponse ToResponseFromEntity(Service entity)
    {
        return new ServiceResponse(entity.ServiceId, entity.Name, entity.Description);
    }
}