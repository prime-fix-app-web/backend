using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Controllers;

/// <summary>
///     REST controller for managing vehicles.
/// </summary>
/// <param name="vehicleQueryService">
///     The vehicle query service for handling read operations.
/// </param>
/// <param name="vehicleCommandService">
///     The vehicle command service for handling write operations.
/// </param>
[ApiController]
[Route("api/v1/vehicles")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Vehicles Endpoints")]
public class VehicleController(IVehicleQueryService vehicleQueryService, IVehicleCommandService vehicleCommandService) : ControllerBase
{
    /// <summary>
    ///     Create a new vehicle
    /// </summary>
    /// <param name="request">
    ///     The vehicle creation request data
    /// </param>
    /// <returns>
    ///     The created vehicle response details
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new vehicle",
        Description = "Creates a new vehicle with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Vehicle created successfully",
        typeof(VehicleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequest request)
    {
        var createVehicleCommand = VehicleAssembler.ToCommandFromRequest(request);
        var vehicleId = await vehicleCommandService.Handle(createVehicleCommand);
        
        /*if (string.IsNullOrWhiteSpace(vehicleId)) return BadRequest();*/

        var getVehicleByIdQuery = new GetVehicleByIdQuery(vehicleId);
        var vehicle = await vehicleQueryService.Handle(getVehicleByIdQuery);
        
        if (vehicle is null) return NotFound();
        
        var vehicleResponse = VehicleAssembler.ToResponseFromEntity(vehicle);
        return Ok(vehicleResponse);
    }
    
    /// <summary>
    ///     Get all vehicles, optionally filtered by maintenance status
    /// </summary>
    /// <param name="maintenanceStatus">
    ///     The maintenance status to filter vehicles by (optional)
    /// </param>
    /// <returns>
    ///     The list of vehicles
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all vehicles",
        Description = "Retrieves a list of all vehicles"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Vehicles retrieved successfully",
        typeof(IEnumerable<VehicleResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllVehicles([FromQuery] int? maintenanceStatus)
    {
        IEnumerable<Vehicle> vehicles;
        
        if (maintenanceStatus is null)
        {
            var getAllVehiclesQuery = new GetAllVehiclesQuery();
            vehicles = await vehicleQueryService.Handle(getAllVehiclesQuery);
        }
        else
        {
            var query = new GetVehicleByMaintenanceStatusQuery(maintenanceStatus.Value);
            vehicles = await vehicleQueryService.Handle(query);
        }
        
        var vehicleResponses = vehicles
            .Select(VehicleAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(vehicleResponses);
    }
    
    /// <summary>
    ///     Get a vehicle by its ID
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique ID of the vehicle
    /// </param>
    /// <returns>
    ///     The vehicle response details
    /// </returns>
    [HttpGet("{vehicleId}")]
    [SwaggerOperation(
        Summary = "Retrieve a vehicle by its ID",
        Description = "Retrieves a vehicle using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Vehicle retrieved successfully",
        typeof(VehicleResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Vehicle not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetVehicleById(int vehicleId)
    {
        var getVehicleByIdQuery = new GetVehicleByIdQuery(vehicleId);
        var vehicle = await vehicleQueryService.Handle(getVehicleByIdQuery);
        
        if (vehicle is null) return NotFound();
        
        var vehicleResponse = VehicleAssembler.ToResponseFromEntity(vehicle);
        return Ok(vehicleResponse);
    }
    
    /// <summary>
    ///     Update an existing vehicle
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique ID of the vehicle to update
    /// </param>
    /// <param name="request">
    ///     The vehicle update request data
    /// </param>
    /// <returns>
    ///     The updated vehicle response details
    /// </returns>
    [HttpPut("{vehicleId}")]
    [SwaggerOperation(
        Summary = "Update an existing vehicle",
        Description = "Update an existing vehicle with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Vehicle updated successfully",
        typeof(VehicleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Vehicle not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateVehicle(int vehicleId, [FromBody] UpdateVehicleRequest request)
    {
        var updateVehicleCommand = VehicleAssembler.ToCommandFromRequest(request, vehicleId);
        var vehicle = await vehicleCommandService.Handle(updateVehicleCommand);
        if (vehicle is null) return BadRequest();
        
        var vehicleResponse = VehicleAssembler.ToResponseFromEntity(vehicle);
        return Ok(vehicleResponse);
    }
    
    /// <summary>
    ///     Delete a vehicle by its ID
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique ID of the vehicle to delete
    /// </param>
    /// <returns>
    ///     No content on successful deletion
    /// </returns>
    [HttpDelete("{vehicleId}")]
    [SwaggerOperation(
        Summary = "Delete a vehicle by its ID",
        Description = "Deletes a vehicle using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Vehicle deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid vehicle ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Vehicle not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteVehicle(int vehicleId)
    {
        var deleteVehicleCommand = new DeleteVehicleCommand(vehicleId);
        var result = await vehicleCommandService.Handle(deleteVehicleCommand);
        
        if (!result) return BadRequest();
        
        return NoContent();
    }
}