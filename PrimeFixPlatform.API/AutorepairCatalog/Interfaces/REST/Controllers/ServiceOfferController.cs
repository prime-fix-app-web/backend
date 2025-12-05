using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Controllers;

/// <summary>
///     Controller responsible for managing ServiceOffer entities within AutoRepair catalogs.
///     Provides endpoints to create and delete service offers associated with specific AutoRepair entities.
/// </summary>
[ApiController]
[Route("api/v1/ServiceOffer")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available ServicesOffer Endpoints")]
public class ServiceOfferController(IAutoRepairCommandService autoRepairCommandService,
                                   IAutoRepairQueryService autoRepairQueryService) : ControllerBase
{
    private readonly IAutoRepairCommandService autoRepairCommandService = autoRepairCommandService;
    private readonly IAutoRepairQueryService autoRepairQueryService = autoRepairQueryService;

    /// <summary>
    ///     Adds a new ServiceOffer to a specific AutoRepair's service catalog.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the AutoRepair to which the service offer will be added.
    /// </param>
    /// <param name="request">
    ///     The request object containing the service offer details (ServiceId, Price, DurationHours).
    /// </param>
    /// <returns>
    ///     Returns the created <see cref="ServiceOffer"/> with status 201 Created.
    ///     Returns 400 BadRequest if the request is invalid.
    ///     Returns 404 NotFound if the specified Service or AutoRepair does not exist.
    /// </returns
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new ServiceOffer",
        Description = "Creates a new ServiceOffer",
        OperationId = "CreateServiceOffer")]
    [SwaggerResponse(StatusCodes.Status201Created, "ServiceOffer created", typeof(ServiceOffer))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Service or AutoRepair not found")]
    public async Task<IActionResult> AddServiceOfferToServiceCatalog(int autoRepairId, [FromBody] RegisterServiceOfferRequest request)
    {
        var command = new AddServiceToAutoRepairServiceCatalogCommand(
            autoRepairId,
            request.ServiceId,
            request.Price,
            request.DurationHours,
            true);
        
        var serviceOffer = await autoRepairCommandService.Handle(command);

        var resource = ServiceOfferAssembler.ToResponseFromEntity(serviceOffer);

        return CreatedAtAction(
            nameof(AddServiceOfferToServiceCatalog),
            new { autoRepairId = autoRepairId, serviceId = request.ServiceId },
            resource
        );
    }

    /// <summary>
    ///     Deletes a ServiceOffer from a specific AutoRepair's service catalog.
    /// </summary>
    /// <param name="autoRepairId">
    ///     The unique identifier of the AutoRepair from which the service offer will be removed.
    /// </param>
    /// <param name="serviceId">
    ///     The unique identifier of the ServiceOffer to delete.
    /// </param>
    /// <returns>
    ///     Returns 200 OK with a boolean indicating successful deletion.
    ///     Returns 404 NotFound if the AutoRepair or ServiceOffer does not exist.
    ///     Returns 400 BadRequest if a domain error occurs while removing the service offer.
    /// </returns>
    [HttpDelete("{autoRepairId}/service/{serviceId}")]
    [SwaggerOperation(
        Summary = "Deletes a ServiceOffer from an AutoRepair's ServiceCatalog",
        Description = "Removes a service offer from the specified AutoRepair's catalog",
        OperationId = "DeleteServiceOffer"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "ServiceOffer successfully deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Service or AutoRepair not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Domain error occurred while removing the service offer")]
    public async Task<IActionResult> DeleteServiceOfferFromCatalog(int autoRepairId, int serviceId)
    {
        var autoRepair = await autoRepairQueryService.GetByIdAsync(autoRepairId);
        if (autoRepair == null)
            return NotFound($"AutoRepair with id {autoRepairId} not found");
        
        var serviceOffer = autoRepair.ServiceOffers.FirstOrDefault(so => so.ServiceId == serviceId);
        if (serviceOffer == null)
            return NotFound($"ServiceOffer with ServiceId {serviceId} not found for AutoRepair {autoRepairId}");

        try
        {
            autoRepair.DeleteOffer(serviceOffer.Service);

            await autoRepairCommandService.Handle(
                new DeleteServiceToAutoRepairServiceCommand(autoRepairId, serviceId)
            );

            return Ok(true);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}