using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Controllers;

/// <summary>
///     REST controller for managing Auto Repairs
/// </summary>
/// <param name="autoRepairQueryService">
///     The service responsible for handling auto repair queries
/// </param>
/// <param name="autoRepairCommandService">
///     The service responsible for handling auto repair commands
/// </param>
[ApiController]
[Route("api/v1/auto_repairs")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Auto Repairs Endpoints")]
public class AutoRepairController(IAutoRepairQueryService autoRepairQueryService, IAutoRepairCommandService autoRepairCommandService) : ControllerBase
{
    /// <summary>
    ///     Create a new auto repair
    /// </summary>
    /// <param name="request">
    ///     The request object containing auto repair data
    /// </param>
    /// <returns>
    ///     The created auto repair response
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new auto repair",
        Description = "Creates a new auto repair with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Auto Repair created successfully",
        typeof(AutoRepairResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateAutoRepair([FromBody] CreateAutoRepairRequest request)
    {
        var createAutoRepairCommand = AutoRepairAssembler.ToCommandFromRequest(request);
        var autoRepairId = await autoRepairCommandService.Handle(createAutoRepairCommand);
        
        if (autoRepairId<0) return BadRequest();

        var getAutoRepairByIdQuery = new GetAutoRepairByIdQuery(autoRepairId);
        var autoRepair = await autoRepairQueryService.Handle(getAutoRepairByIdQuery);
        
        if (autoRepair is null) return NotFound();
        
        var autoRepairResponse = AutoRepairAssembler.ToResponseFromEntity(autoRepair);
        return Ok(autoRepairResponse);
    }
    
    /// <summary>
    ///     Get all auto repairs
    /// </summary>
    /// <returns>
    ///     The list of all auto repairs
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all auto repairs",
        Description = "Retrieves a list of all auto repairs"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Auto Repairs retrieved successfully",
        typeof(IEnumerable<AutoRepairResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllAutoRepairs()
    {
        var getAllAutoRepairsQuery = new GetAllAutoRepairsQuery();
        var autoRepairs = await autoRepairQueryService.Handle(getAllAutoRepairsQuery);
        
        var autoRepairResponses = autoRepairs
            .Select(AutoRepairAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(autoRepairResponses);
    }
    
    /// <summary>
    ///     Get an auto repair by its ID
    /// </summary>
    /// <param name="id_auto_repair">
    ///     The unique ID of the auto repair
    /// </param>
    /// <returns>
    ///     The auto repair response
    /// </returns>
    [HttpGet("{id_auto_repair}")]
    [SwaggerOperation(
        Summary = "Retrieve a auto repair by its ID",
        Description = "Retrieves a auto repair using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Auto repair retrieved successfully",
        typeof(AutoRepairResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Auto repair not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAutoRepairById(int id_auto_repair)
    {
        var getAutoRepairByIdQuery = new GetAutoRepairByIdQuery(id_auto_repair);
        var autoRepair = await autoRepairQueryService.Handle(getAutoRepairByIdQuery);
        
        if (autoRepair is null) return NotFound();
        
        var autoRepairResponse = AutoRepairAssembler.ToResponseFromEntity(autoRepair);
        return Ok(autoRepairResponse);
    }
    
    /// <summary>
    ///     Update an existing auto repair
    /// </summary>
    /// <param name="id_auto_repair">
    ///     The unique ID of the auto repair to update
    /// </param>
    /// <param name="request">
    ///     The request object containing updated auto repair data
    /// </param>
    /// <returns>
    ///     The updated auto repair response
    /// </returns>
    [HttpPut("{id_auto_repair}")]
    [SwaggerOperation(
        Summary = "Update an existing auto repair",
        Description = "Update an existing auto repair with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Auto repair updated successfully",
        typeof(AutoRepairResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Auto repair not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateAutoRepair(int id_auto_repair, [FromBody] UpdateAutoRepairRequest request)
    {
        var updateAutoRepairCommand = AutoRepairAssembler.ToCommandFromRequest(request, id_auto_repair);
        var updateAutoRepair = await autoRepairCommandService.Handle(updateAutoRepairCommand);
        if (updateAutoRepair is null) return BadRequest();
        
        var autoRepairResponse = AutoRepairAssembler.ToResponseFromEntity(updateAutoRepair);
        return Ok(autoRepairResponse);
    }
    
    /// <summary>
    ///     Delete an auto repair by its ID
    /// </summary>
    /// <param name="id_auto_repair">
    ///     The unique ID of the auto repair to delete
    /// </param>
    /// <returns>
    ///     The result of the delete operation
    /// </returns>
    [HttpDelete("{id_auto_repair}")]
    [SwaggerOperation(
        Summary = "Delete a auto repair by its ID",
        Description = "Deletes a auto repair using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Auto repair deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid auto repair ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Auto repair not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteAutoRepair(int id_auto_repair)
    {
        var deleteAutoRepairCommand = new DeleteAutoRepairCommand(id_auto_repair);
        var result = await autoRepairCommandService.Handle(deleteAutoRepairCommand);
        
        if (!result) return NotFound();
        
        return NoContent();
    }
}