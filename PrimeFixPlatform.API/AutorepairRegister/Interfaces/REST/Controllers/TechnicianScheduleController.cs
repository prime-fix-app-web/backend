using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.AutorepairRegister.Interfaces.REST.Controllers;

/// <summary>
///     REST controller for managing technician schedules
/// </summary>
/// <param name="technicianScheduleQueryService">
///     The technician schedule query service
/// </param>
/// <param name="technicianScheduleCommandService">
///     The technician schedule command service
/// </param>
[ApiController]
[Route("api/v1/technician_schedules")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Technician Schedules Endpoints")]
public class TechnicianScheduleController(ITechnicianScheduleQueryService technicianScheduleQueryService, ITechnicianScheduleCommandService technicianScheduleCommandService)
: ControllerBase
{
    /// <summary>
    ///     Create a new technician schedule
    /// </summary>
    /// <param name="request">
    ///     The create technician schedule request
    /// </param>
    /// <returns>
    ///     The created technician schedule
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new technician schedule",
        Description = "Creates a new technician schedule with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Technician Schedule created successfully",
        typeof(TechnicianScheduleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateTechnicianSchedule([FromBody] CreateTechnicianScheduleRequest request)
    {
        var createTechnicianScheduleCommand = TechnicianScheduleAssembler.ToCommandFromRequest(request);
        var technicianScheduleId = await technicianScheduleCommandService.Handle(createTechnicianScheduleCommand);
        
        if (string.IsNullOrWhiteSpace(technicianScheduleId)) return BadRequest();
        
        var getTechnicianScheduleByIdQuery = new GetTechnicianScheduleByIdQuery(technicianScheduleId);
        var technicianSchedule = await technicianScheduleQueryService.Handle(getTechnicianScheduleByIdQuery);
        
        if (technicianSchedule is null) return NotFound();
        
        var technicianScheduleResponse = TechnicianScheduleAssembler.ToResponseFromEntity(technicianSchedule);
        return Ok(technicianScheduleResponse);
    }
    
    /// <summary>
    ///     Get all technician schedules
    /// </summary>
    /// <returns>
    ///     The list of all technician schedules
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all technician schedules",
        Description = "Retrieves a list of all technicians"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Technician Schedules retrieved successfully",
        typeof(IEnumerable<TechnicianScheduleResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllTechnicianSchedules()
    {
        var getAllTechnicianSchedulesQuery = new GetAllTechnicianSchedulesQuery();
        var technicianSchedules = await technicianScheduleQueryService.Handle(getAllTechnicianSchedulesQuery);
        
        var technicianScheduleResponses = technicianSchedules
            .Select(TechnicianScheduleAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(technicianScheduleResponses);
    }
    
    /// <summary>
    ///     Get a technician schedule by its ID
    /// </summary>
    /// <param name="id_schedule">
    ///     The unique ID of the technician schedule
    /// </param>
    /// <returns>
    ///     The technician schedule with the specified ID
    /// </returns>
    [HttpGet("{id_schedule}")]
    [SwaggerOperation(
        Summary = "Retrieve a technician schedule by its ID",
        Description = "Retrieves a technician schedule using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Technician Schedule retrieved successfully",
        typeof(TechnicianScheduleResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Technician Schedule not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetTechnicianScheduleById([FromRoute] string id_schedule)
    {
        var getTechnicianScheduleByIdQuery = new GetTechnicianScheduleByIdQuery(id_schedule);
        var technicianSchedule = await technicianScheduleQueryService.Handle(getTechnicianScheduleByIdQuery);
        
        if (technicianSchedule is null) return BadRequest();
        
        var technicianScheduleResponse = TechnicianScheduleAssembler.ToResponseFromEntity(technicianSchedule);
        return Ok(technicianScheduleResponse);
    }
    
    /// <summary>
    ///     Update an existing technician schedule
    /// </summary>
    /// <param name="id_schedule">
    ///     The unique ID of the technician schedule to update
    /// </param>
    /// <param name="request">
    ///     The update technician schedule request
    /// </param>
    /// <returns>
    ///     The updated technician schedule
    /// </returns>
    [HttpPut("{id_schedule}")]
    [SwaggerOperation(
        Summary = "Update an existing technician schedule",
        Description = "Update an existing technician schedule with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Technician Schedule updated successfully",
        typeof(TechnicianScheduleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Technician Schedule not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateTechnicianSchedule([FromRoute] string id_schedule, [FromBody] UpdateTechnicianScheduleRequest request)
    {
        var updateTechnicianScheduleCommand = TechnicianScheduleAssembler.ToCommandFromRequest(request, id_schedule);
        var updatedTechnicianSchedule = await technicianScheduleCommandService.Handle(updateTechnicianScheduleCommand);
        if (updatedTechnicianSchedule is null) return BadRequest();
        
        var technicianScheduleResponse = TechnicianScheduleAssembler.ToResponseFromEntity(updatedTechnicianSchedule);
        return Ok(technicianScheduleResponse);
    }
    
    /// <summary>
    ///     Delete a technician schedule by its ID
    /// </summary>
    /// <param name="id_schedule">
    ///     The unique ID of the technician schedule to delete
    /// </param>
    /// <returns>
    ///     The result of the delete operation
    /// </returns>
    [HttpDelete("{id_schedule}")]
    [SwaggerOperation(
        Summary = "Delete a technician schedule by its ID",
        Description = "Deletes a technician schedule using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Technician Schedule deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid location ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Technician Schedule not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteTechnicianSchedule([FromRoute] string id_schedule)
    {
        var deleteTechnicianScheduleCommand = new DeleteTechnicianScheduleCommand(id_schedule);
        var result = await technicianScheduleCommandService.Handle(deleteTechnicianScheduleCommand);
        
        if (!result) return NotFound();
        
        return NoContent();
    }
}