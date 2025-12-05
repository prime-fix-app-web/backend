using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Controllers;

/// <summary>
///     Controller responsible for managing Service entities.
///     Provides endpoints for creating, updating, deleting, and retrieving services.
/// </summary>
[ApiController]
[Route("api/v1/Services")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Services Endpoints")]
public class ServiceController(IServiceCommandService serviceCommandService, IServiceQueryService serviceQueryService): ControllerBase
{
    
    /// <summary>
    ///     Creates a new Service entity.
    /// </summary>
    /// <param name="request">
    ///     The request object containing the data required to create a new Service.
    /// </param>
    /// <returns>
    ///     Returns the created Service as a <see cref="ServiceResponse"/> with status 200 OK.
    ///     Returns 400 BadRequest if creation fails.
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Services",
        Description = "Create a new Services",
        OperationId = "CreateService")]
    [SwaggerResponse(StatusCodes.Status200OK, "Creates a new Service")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request")]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceRequest request)
    {
        var createServiceCommand = ServiceAssembler.ToCommandFromRequest(request);
        var serviceId = await serviceCommandService.Handle(createServiceCommand);
        
        var getServiceByIdQuery = new GetServiceByIdQuery(serviceId);
        /*if (service == null) return BadRequest();*/
        var service = await serviceQueryService.Handle(getServiceByIdQuery);
        
        if(service is null) return BadRequest();
        
        var serviceResponse = ServiceAssembler.ToResponseFromEntity(service);
        return Ok(serviceResponse);
    }
    
    /// <summary>
    ///     Retrieves all Service entities.
    /// </summary>
    /// <returns>
    ///     Returns a list of all services as <see cref="ServiceResponse"/> objects with status 200 OK.
    ///     Returns 400 BadRequest if retrieval fails.
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Services",
        Description = "Get All Services",
        OperationId = "GetAllServices")]
    [SwaggerResponse(StatusCodes.Status200OK, "Gets all Services")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request")]
    public async Task<IActionResult> GetAllService()
    {
        var services = await serviceQueryService.Handle(new GetAllServicesQuery());
        var serviceResource = services.Select(ServiceAssembler.ToResponseFromEntity);
        return Ok(serviceResource);
    }
    
    /// <summary>
    ///     Deletes a Service entity by its unique identifier.
    /// </summary>
    /// <param name="serviceId">
    ///     The unique identifier of the Service to delete.
    /// </param>
    /// <returns>
    ///     Returns the result of the deletion operation with status 200 OK.
    ///     Returns 400 BadRequest if deletion fails.
    /// </returns>
    [HttpDelete]
    [SwaggerOperation(
        Summary = "Delete Service",
        Description = "Delete Service",
        OperationId = "DeleteService")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletes Service")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request")]
    public async Task<IActionResult> DeleteService(int serviceId)
    {
        var deleteService = new DeleteServiceCommand(serviceId);
        var result = await serviceCommandService.Handle(deleteService);
        if(result == null) return BadRequest();
        return Ok(result);
    }
    
    /// <summary>
    ///     Updates an existing Service entity.
    /// </summary>
    /// <param name="request">
    ///     The request object containing updated Service data.
    /// </param>
    /// <param name="serviceId">
    ///     The unique identifier of the Service to update.
    /// </param>
    /// <returns>
    ///     Returns the updated Service as a <see cref="ServiceResponse"/> with status 200 OK.
    ///     Returns 400 BadRequest if the update fails.
    /// </returns>
    [HttpPut]
    [SwaggerOperation(
        Summary = "Update Service",
        Description = "Update Service",
        OperationId = "UpdateService")]
    [SwaggerResponse(StatusCodes.Status200OK, "Updates Service")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request")]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand request, int serviceId)
    {
        var updateService = ServiceAssembler.ToCommandFromRequest(request, serviceId);
        var service = await serviceCommandService.Handle(updateService);
        if (service is null) return BadRequest();
        
        var serviceResource = ServiceAssembler.ToResponseFromEntity(service);
        return Ok(serviceResource);
    }
    
}