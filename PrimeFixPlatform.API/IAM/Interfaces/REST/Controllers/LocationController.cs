using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.IAM.Domain.Model.Commands;
using PrimeFixPlatform.API.IAM.Domain.Model.Queries;
using PrimeFixPlatform.API.IAM.Domain.Services;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PrimeFixPlatform.API.IAM.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Controllers;

/// <summary>
///     REST controller for managing locations
/// </summary>
/// <param name="locationQueryService">
///     The location query service
/// </param>
/// <param name="locationCommandService">
///     The location command service
/// </param>
[ApiController]
[Authorize]
[Route("api/v1/locations")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Locations Endpoints")]
public class LocationController(ILocationQueryService locationQueryService, ILocationCommandService locationCommandService) : ControllerBase
{
    /// <summary>
    ///     Create a new location
    /// </summary>
    /// <param name="request">
    ///     The create location request
    /// </param>
    /// <returns>
    ///     The created location response
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new location",
        Description = "Creates a new location with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Location created successfully",
        typeof(LocationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
    {
        var createLocationCommand = LocationAssembler.ToCommandFromRequest(request);
        var locationId = await locationCommandService.Handle(createLocationCommand);
        
        if (locationId<0) return BadRequest();

        var getLocationByIdQuery = new GetLocationByIdQuery(locationId);
        var location = await locationQueryService.Handle(getLocationByIdQuery);
        
        if (location is null) return NotFound();
        
        var locationResponse = LocationAssembler.ToResponseFromEntity(location);
        return Ok(locationResponse);
    }
    
    /// <summary>
    ///     Get all locations
    /// </summary>
    /// <returns>
    ///     A list of location responses
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all locations",
        Description = "Retrieves a list of all locations"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Locations retrieved successfully",
        typeof(IEnumerable<LocationResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllLocations()
    {
        var getAllLocationsQuery = new GetAllLocationsQuery();
        var locations = await locationQueryService.Handle(getAllLocationsQuery);
        
        var locationResponses = locations
            .Select(LocationAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(locationResponses);
    }
    
    /// <summary>
    ///     Get a location by its ID
    /// </summary>
    /// <param name="location_id">
    ///     The unique ID of the location
    /// </param>
    /// <returns>
    ///     The location response
    /// </returns>
    [HttpGet("{location_id}")]
    [SwaggerOperation(
        Summary = "Retrieve a location by its ID",
        Description = "Retrieves a location using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Location retrieved successfully",
        typeof(LocationResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Location not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetLocationById(int location_id)
    {
        var getLocationByIdQuery = new GetLocationByIdQuery(location_id);
        var location = await locationQueryService.Handle(getLocationByIdQuery);
        
        if (location is null) return NotFound();
        
        var locationResponse = LocationAssembler.ToResponseFromEntity(location);
        return Ok(locationResponse);
    }

    /// <summary>
    ///     Update an existing location
    /// </summary>
    /// <param name="location_id">
    ///     The unique ID of the location to update
    /// </param>
    /// <param name="request">
    ///     The update location request
    /// </param>
    /// <returns>
    ///     The updated location response
    /// </returns>
    [HttpPut("{location_id}")]
    [SwaggerOperation(
        Summary = "Update an existing location",
        Description = "Update an existing location with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Location updated successfully",
        typeof(LocationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Location not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateLocation(int location_id,[FromBody] UpdateLocationRequest request)
    {
        var updateLocationCommand = LocationAssembler.ToCommandFromRequest(request, location_id);
        var updateLocation = await locationCommandService.Handle(updateLocationCommand);
        if (updateLocation is null) return BadRequest();
        
        var locationResponse = LocationAssembler.ToResponseFromEntity(updateLocation);;
        return Ok(locationResponse);
    }
    
    /// <summary>
    ///     Delete a location by its ID
    /// </summary>
    /// <param name="location_id">
    ///     The unique ID of the location to delete
    /// </param>
    /// <returns>
    ///     No content response on successful deletion
    /// </returns>
    [HttpDelete("{location_id}")]
    [SwaggerOperation(
        Summary = "Delete a location by its ID",
        Description = "Deletes a location using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Location deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid location ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Location not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteLocationById(int location_id)
    {
        var deleteLocationCommand = new DeleteLocationCommand(location_id);
        var result = await locationCommandService.Handle(deleteLocationCommand);
        
        if (!result) return NotFound();
        
        return NoContent();
    }
}