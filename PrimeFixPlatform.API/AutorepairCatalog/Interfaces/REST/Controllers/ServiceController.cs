using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/Services")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Services Endpoints")]
public class ServiceController(IServiceCommandService serviceCommandService, IServiceQueryService serviceQueryService): ControllerBase
{

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
        var service = await serviceCommandService.Handle(
            createServiceCommand);
        if (service == null) return BadRequest();
        var serviceResource = ServiceAssembler.ToResponseFromEntity(service);
        return Ok(serviceResource);
    }

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