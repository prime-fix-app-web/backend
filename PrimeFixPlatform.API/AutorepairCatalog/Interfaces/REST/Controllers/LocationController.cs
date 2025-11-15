using System.Net.Mime;
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
///     REST controller for managing locations
/// </summary>
/// <param name="locationQueryService">
///     The location query service
/// </param>
/// <param name="locationCommandService">
///     The location command service
/// </param>
[ApiController]
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
        
        if (string.IsNullOrWhiteSpace(locationId)) return BadRequest();

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
    /// <param name="id_location">
    ///     The unique ID of the location
    /// </param>
    /// <returns>
    ///     The location response
    /// </returns>
    [HttpGet("{id_location}")]
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
    public async Task<IActionResult> GetLocationById(string id_location)
    {
        var getLocationByIdQuery = new GetLocationByIdQuery(id_location);
        var location = await locationQueryService.Handle(getLocationByIdQuery);
        
        if (location is null) return NotFound();
        
        var locationResponse = LocationAssembler.ToResponseFromEntity(location);
        return Ok(locationResponse);
    }

    /// <summary>
    ///     Update an existing location
    /// </summary>
    /// <param name="id_location">
    ///     The unique ID of the location to update
    /// </param>
    /// <param name="request">
    ///     The update location request
    /// </param>
    /// <returns>
    ///     The updated location response
    /// </returns>
    [HttpPut("{id_location}")]
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
    public async Task<IActionResult> UpdateLocation(string id_location,[FromBody] UpdateLocationRequest request)
    {
        var updateLocationCommand = LocationAssembler.ToCommandFromRequest(request, id_location);
        var updateLocation = await locationCommandService.Handle(updateLocationCommand);
        if (updateLocation is null) return BadRequest();
        
        var locationResponse = LocationAssembler.ToResponseFromEntity(updateLocation);;
        return Ok(locationResponse);
    }
    
    /// <summary>
    ///     Delete a location by its ID
    /// </summary>
    /// <param name="id_location">
    ///     The unique ID of the location to delete
    /// </param>
    /// <returns>
    ///     No content response on successful deletion
    /// </returns>
    [HttpDelete("{id_location}")]
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
    public async Task<IActionResult> DeleteLocationById(string id_location)
    {
        var deleteLocationCommand = new DeleteLocationCommand(id_location);
        var result = await locationCommandService.Handle(deleteLocationCommand);
        
        if (!result) return NotFound();
        
        return NoContent();
    }
}