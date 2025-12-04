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
///     REST controller for managing technicians
/// </summary>
/// <param name="technicianQueryService">
///     The technician query service
/// </param>
/// <param name="technicianCommandService">
///     The technician command service
/// </param>
[ApiController]
[Route("api/v1/technicians")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Technicians Endpoints")]
public class TechnicianController(ITechnicianQueryService technicianQueryService, ITechnicianCommandService technicianCommandService) : ControllerBase
{
    /// <summary>
    ///     Create a new technician
    /// </summary>
    /// <param name="request">
    ///     The create technician request
    /// </param>
    /// <returns>
    ///     The created technician response
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new technician",
        Description = "Creates a new technician with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Technician created successfully",
        typeof(TechnicianResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateTechnician([FromBody] CreateTechnicianRequest request)
    {
        var createTechnicianCommand = TechnicianAssembler.ToCommandFromRequest(request);
        var technicianId = await technicianCommandService.Handle(createTechnicianCommand);

        var getTechnicianByIdQuery = new GetTechnicianByIdQuery(technicianId);
        var technician = await technicianQueryService.Handle(getTechnicianByIdQuery);
        
        if (technician is null) return NotFound();
        
        var technicianResponse = TechnicianAssembler.ToResponseFromEntity(technician);
        return Ok(technicianResponse);
    }
    
    /// <summary>
    ///     Get all technicians
    /// </summary>
    /// <returns>
    ///     The list of technician responses
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all technicians",
        Description = "Retrieves a list of all technicians"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Technicians retrieved successfully",
        typeof(IEnumerable<TechnicianResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllTechnicians()
    {
        var getAllTechniciansQuery = new GetAllTechniciansQuery();
        var technicians = await technicianQueryService.Handle(getAllTechniciansQuery);
        
        var technicianResponses = technicians
            .Select(TechnicianAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(technicianResponses);
    }
    
    /// <summary>
    ///     Get a technician by its ID
    /// </summary>
    /// <param name="technician_id">
    ///     The unique ID of the technician
    /// </param>
    /// <returns>
    ///     The technician response
    /// </returns>
    [HttpGet("{technician_id}")]
    [SwaggerOperation(
        Summary = "Retrieve a technician by its ID",
        Description = "Retrieves a technician using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Technician retrieved successfully",
        typeof(TechnicianResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Technician not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetTechnicianById([FromRoute] int technician_id)
    {
        var getTechnicianByIdQuery = new GetTechnicianByIdQuery(technician_id);
        var technician = await technicianQueryService.Handle(getTechnicianByIdQuery);
        
        if (technician is null) return NotFound();
        
        var technicianResponse = TechnicianAssembler.ToResponseFromEntity(technician);
        return Ok(technicianResponse);
    }
    
    /// <summary>
    ///     Update an existing technician
    /// </summary>
    /// <param name="technician_id">
    ///     The unique ID of the technician to update
    /// </param>
    /// <param name="request">
    ///     The update technician request
    /// </param>
    /// <returns>
    ///     The updated technician response
    /// </returns>
    [HttpPut("{technician_id}")]
    [SwaggerOperation(
        Summary = "Update an existing technician",
        Description = "Update an existing technician with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Technician updated successfully",
        typeof(TechnicianResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Technician not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateTechnician([FromRoute] int technician_id, [FromBody] UpdateTechnicianRequest request)
    {
        var updateTechnicianCommand = TechnicianAssembler.ToCommandFromRequest(request, technician_id);
        var updateTechnician = await technicianCommandService.Handle(updateTechnicianCommand);
        if (updateTechnician is null) return BadRequest();
        
        var technicianResponse = TechnicianAssembler.ToResponseFromEntity(updateTechnician);
        return Ok(technicianResponse);
    }
    
    /// <summary>
    ///     Delete a technician by its ID
    /// </summary>
    /// <param name="technician_id">
    ///     The unique ID of the technician to delete
    /// </param>
    /// <returns>
    ///     No content response
    /// </returns>
    [HttpDelete("{technician_id}")]
    [SwaggerOperation(
        Summary = "Delete a technician by its ID",
        Description = "Deletes a technician using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Technician deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid location ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Technician not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteTechnician([FromRoute] int technician_id)
    {
        var deleteTechnicianCommand = new DeleteTechnicianCommand(technician_id);
        var result = await technicianCommandService.Handle(deleteTechnicianCommand);
        
        if (!result) return NotFound();
        
        return NoContent();
    }
}