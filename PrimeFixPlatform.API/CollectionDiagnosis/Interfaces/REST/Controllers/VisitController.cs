using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/visits")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Services Endpoints")]
public class VisitController(IVisitQueryService visitQueryService,
    IVisitCommandService visitCommandService,
    IExpectedVisitCommandService expectedVisitCommandService):ControllerBase
{

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Visit Resource",
        Description = "Creates a new Visit Resource",
        OperationId = "CreateVisit")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Creates a new Visit Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Creates a new Visit Resource")]
    public async Task<IActionResult> CreateVisit([FromBody] CreateVisitRequest request)
    {
        var createVisitCommand = VisitAssembler.ToCommandFromRequest(request);
        var visit = await visitCommandService.Handle(createVisitCommand);
        if (visit == null)  return BadRequest();
        var visitResource = VisitAssembler.ToResponseFromEntity(visit);
        return Ok(visitResource);
    }


    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a list of Visit Resource",
        Description = "Gets a list of Visit Resource",
        OperationId = "GetVisits")]
    [SwaggerResponse(StatusCodes.Status200OK, "Gets a list of Visit Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Gets a list of Visit Resource")]
    public async Task<IActionResult> GetAllVisits()
    {
        var visits = await visitQueryService.Handle(new GetAllVisitsQuery());
        var visitResource = visits.Select(VisitAssembler.ToResponseFromEntity);
        return Ok(visitResource);
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Deletes a Visit Resource",
        Description = "Deletes a Visit Resource",
        OperationId = "DeleteVisit")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletes a Visit Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Deletes a Visit Resource")]
    public async Task<IActionResult> DeleteVisit(int visitId)
    {
        var deleteVisit = new DeleteVisitCommand(visitId);
        var visit = await visitCommandService.Handle(deleteVisit);
        if (visit == null) return BadRequest();
        return Ok(visit);
    }
    
    [HttpPut("{visit_id}")]
    [SwaggerOperation(
        Summary = "Cancels a Visit Resource",
        Description = "Cancels a Visit Resource",
        OperationId = "CancelVisit")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cancels a Visit Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Cancels a Visit Resource")]
    public async Task<IActionResult> CancelVisit(int visitId)
    {
        var cancelVisit = new CancelVisitCommand(visitId);
        await expectedVisitCommandService.Handle(cancelVisit);
        return NoContent();
    }
    
}