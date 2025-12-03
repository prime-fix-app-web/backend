using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Controllers;


[ApiController]
[Route("api/v1/expectedVisits")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Expected Visit")]
public class ExpectedVisitController(IExpectedVisitCommandService expectedVisitCommandService, IExpectedVisitQueryService expectedVisitQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Expected Resource",
        Description = "Creates a new Expected Resource",
        OperationId = "CreateExpectedVisit"
        )]
    [SwaggerResponse(200, "Expected Resource", typeof(ExpectedVisit))]
    [SwaggerResponse(400, "Expected Resource", typeof(ExpectedVisit))]
    public async Task<IActionResult> CreateExpected([FromBody] CreateExpectedVisitRequest request)
    {
        var createExpectedCommand = ExpectedVisitAssembler.ToCommandFromRequest(request);
        var expected = await expectedVisitCommandService.Handle(createExpectedCommand);
        if(expected == null) return BadRequest();
        var expectedResource = ExpectedVisitAssembler.ToResponseFromEntity(expected);
        return Ok(expectedResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets Expected Resource",
        Description = "Gets Expected Resource",
        OperationId = "GetExpectedVisit"
        )]
    [SwaggerResponse(200, "Expected Resource", typeof(ExpectedVisit))]
    public async Task<IActionResult> GetAllExpectedVisit()
    {
        var expected = await expectedVisitQueryService.Handle(new GetAllExpectedVisitsQuery());
        var expectedResource = expected.Select(ExpectedVisitAssembler.ToResponseFromEntity);
        return Ok(expectedResource);
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Deletes Expected Resource",
        Description = "Deletes Expected Resource",
        OperationId = "DeleteExpectedVisit"
        )]
    [SwaggerResponse(200, "Expected Resource", typeof(ExpectedVisit))]
    [SwaggerResponse(400, "Expected Resource", typeof(ExpectedVisit))]
    public async Task<IActionResult> DeleteExpected(int expectedVisitId)
    {
        var deleteExpected = new DeleteExpectedVisitCommand(expectedVisitId);
        var result = await expectedVisitCommandService.Handle(deleteExpected);
        if(result == null) return BadRequest();
        return Ok(result);
    }
    
    [HttpPut("{expectedVisitId}")]
    [SwaggerOperation(
        Summary = "Updates Expected Visit",
        Description = "Updates Expected Visit",
        OperationId = "UpdateExpectedVisit")]
    [SwaggerResponse(200, "Expected Resource", typeof(ExpectedVisit))]
    [SwaggerResponse(400, "Expected Resource", typeof(ExpectedVisit))]
    public async Task<IActionResult> UpdateExpected([FromBody] UpdateExpectedVisitRequest request)
    {
        var updateExpected = ExpectedVisitAssembler.ToCommandFromRequest(request);
        var expected = await expectedVisitCommandService.Handle(updateExpected);
        if(expected is null) return BadRequest();
        
        var expectedResponse = ExpectedVisitAssembler.ToResponseFromEntity(expected);
        return Ok(expectedResponse);
    }

    
    [HttpPut("{expectedId}/status")]
    [SwaggerOperation(
        Summary = "Updates Expected Visit",
        Description = "Updates Expected Visit",
        OperationId = "UpdateExpectedVisit")]
    [SwaggerResponse(200, "Expected Resource", typeof(ExpectedVisit))]
    [SwaggerResponse(400, "Expected Resource", typeof(ExpectedVisit))]
    public async Task<IActionResult> UpdateStatusExpectedVisit(int expectedVisitId,
        [FromBody] UpdateStatusExpectedVisitRequest request)
    {
        var updateExpectedVisit = ExpectedVisitAssembler.ToCommandFromRequestStatus(request, expectedVisitId);
        var expectedVisit = await expectedVisitCommandService.Handle(updateExpectedVisit);
        if (expectedVisit is null) return BadRequest();
        
        var expectedResponse = ExpectedVisitAssembler.ToResponseFromEntity(expectedVisit);
        return Ok(expectedResponse);
    }
    
}