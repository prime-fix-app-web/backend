using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Controllers;

/// <summary>
///     Controller for managing expected visits.
/// </summary>
/// <param name="expectedVisitCommandService">
///     The expected visit command service
/// </param>
/// <param name="expectedVisitQueryService">
///     The expected visit query service
/// </param>
[ApiController]
[Route("api/v1/expected_visits")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Expected Visit")]
public class ExpectedVisitController(IExpectedVisitCommandService expectedVisitCommandService, IExpectedVisitQueryService expectedVisitQueryService) : ControllerBase
{
    /// <summary>
    ///     Create a new expected visit
    /// </summary>
    /// <param name="request">
    ///     The request to create an expected visit
    /// </param >
    /// <returns>
    ///     The created expected visit response
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new expected visit",
        Description = "Creates a new expected visit with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Expected Visit created successfully",
        typeof(ExpectedVisitResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateExpected([FromBody] CreateExpectedVisitRequest request)
    {
        var createExpectedCommand = ExpectedVisitAssembler.ToCommandFromRequest(request);
        var expectedId = await expectedVisitCommandService.Handle(createExpectedCommand);
        var getExpectedVisitByIdQuery = new GetExpectedVisitByIdQuery(expectedId);
        var expected = await expectedVisitQueryService.Handle(getExpectedVisitByIdQuery);
        if(expected is null) return BadRequest();
        var expectedResource = ExpectedVisitAssembler.ToResponseFromEntity(expected);
        return Ok(expectedResource);
    }

    /// <summary>
    ///     Get all expected visits
    /// </summary>
    /// <returns>
    ///     A list of expected visit responses
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all expected visits",
        Description = "Retrieves a list of all expected visits"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Expected Visits retrieved successfully",
        typeof(IEnumerable<ExpectedVisitResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllExpectedVisit()
    {
        var expected = await expectedVisitQueryService.Handle(new GetAllExpectedVisitsQuery());
        var expectedResource = expected.Select(ExpectedVisitAssembler.ToResponseFromEntity);
        return Ok(expectedResource);
    }
    
    /// <summary>
    ///     Get expected visit by ID
    /// </summary>
    /// <param name="expected_visit_id">
    ///     The ID of the expected visit
    /// </param>
    /// <returns></returns>
    [HttpGet("{expected_visit_id}")]
    [SwaggerOperation(
        Summary = "Retrieve a expected visit by its ID",
        Description = "Retrieves a expected visit using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Expected Visit retrieved successfully",
        typeof(ExpectedVisitResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Expected Visit not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetExpectedById(int expected_visit_id)
    {
        var getExpectedByIdQuery = new GetExpectedVisitByIdQuery(expected_visit_id);
        var expected = await expectedVisitQueryService.Handle(getExpectedByIdQuery);
        if(expected is null) return NotFound();
        var expectedResource = ExpectedVisitAssembler.ToResponseFromEntity(expected);
        return Ok(expectedResource);
    }

    /// <summary>
    ///     Delete expected visit by ID
    /// </summary>
    /// <param name="expectedVisitId">
    ///     The ID of the expected visit
    /// </param>
    /// <returns>
    ///     The action result indicating the outcome of the delete operation
    /// </returns>
    [HttpDelete]
    [SwaggerOperation(
        Summary = "Delete a expected visit by its ID",
        Description = "Deletes a expected visit using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Expected Visit deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid Expected Visit ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Expected Visit not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteExpected(int expectedVisitId)
    {
        var deleteExpected = new DeleteExpectedVisitCommand(expectedVisitId);
        var result = await expectedVisitCommandService.Handle(deleteExpected);
        if(result == null) return BadRequest();
        return Ok(result);
    }
    
    /// <summary>
    ///     Update an existing expected visit
    /// </summary>
    /// <param name="expected_visit_id">
    ///     The ID of the expected visit to update
    /// </param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{expected_visit_id}")]
    [SwaggerOperation(
        Summary = "Update an existing expected visit",
        Description = "Update an existing expected visit with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Expected Visit updated successfully",
        typeof(ExpectedVisitResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Expected Visit not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateExpected(int expected_visit_id, [FromBody] UpdateExpectedVisitRequest request)
    {
        var updateExpected = ExpectedVisitAssembler.ToCommandFromRequest(request, expected_visit_id);
        var expected = await expectedVisitCommandService.Handle(updateExpected);
        if(expected is null) return BadRequest();
        
        var expectedResponse = ExpectedVisitAssembler.ToResponseFromEntity(expected);
        return Ok(expectedResponse);
    }

    
    /// <summary>
    ///     Update the status of an existing expected visit
    /// </summary>
    /// <param name="expected_visit_id">
    ///     The ID of the expected visit to update
    /// </param >
    /// <param name="request">
    ///     The update status expected visit request
    /// </param>
    /// <returns>
    ///     The updated expected visit response
    /// </returns>
    [HttpPut("{expected_visit_id}/status")]
    [SwaggerOperation(
        Summary = "Updates Expected Visit",
        Description = "Updates Expected Visit",
        OperationId = "UpdateExpectedVisitStatus")]
    [SwaggerResponse(200, "Expected Resource", typeof(ExpectedVisit))]
    [SwaggerResponse(400, "Expected Resource", typeof(ExpectedVisit))]
    public async Task<IActionResult> UpdateStatusExpectedVisit(int expected_visit_id,
        [FromBody] UpdateStatusExpectedVisitRequest request)
    {
        var updateExpectedVisit = ExpectedVisitAssembler.ToCommandFromRequestStatus(request, expected_visit_id);
        var expectedVisit = await expectedVisitCommandService.Handle(updateExpectedVisit);
        if (expectedVisit is null) return BadRequest();
        
        var expectedResponse = ExpectedVisitAssembler.ToResponseFromEntity(expectedVisit);
        return Ok(expectedResponse);
    }
    
}