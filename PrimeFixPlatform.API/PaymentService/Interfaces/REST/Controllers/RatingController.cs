using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.PaymentService.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Controllers;

/// <summary>
///     REST controller for managing ratings.
/// </summary>
/// <param name="ratingQueryService">
///     The rating query service for handling read operations.
/// </param>
/// <param name="ratingCommandService">
///     The rating command service for handling write operations.
/// </param>
[ApiController]
[Route("api/v1/ratings")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Ratings Endpoints")]
public class RatingController(IRatingQueryService ratingQueryService, 
                            IRatingCommandService ratingCommandService) : ControllerBase
{
    
    /// <summary>
    ///     Create a new rating
    /// </summary>
    /// <param name="request">
    ///     The rating creation request data
    /// </param>
    /// <returns>
    ///     The created rating response details
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new rating",
        Description = "Creates a new rating with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Rating created successfully",
        typeof(RatingResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateRating([FromBody] CreateRatingRequest request)
    {
        var createRatingCommand = RatingAssembler.ToCommandFromRequest(request);
        var ratingId = await ratingCommandService.Handle(createRatingCommand);
        
        if (string.IsNullOrWhiteSpace(ratingId)) return BadRequest();

        var getRatingByIdQuery = new GetRatingByIdQuery(ratingId);
        var rating = await ratingQueryService.Handle(getRatingByIdQuery);
        
        if (rating is null) return NotFound();
        
        var ratingResponse = RatingAssembler.ToResponseFromEntity(rating);
        return Ok(ratingResponse);
    }
    
    /// <summary>
    ///     Get all ratings, optionally filtered by auto repair ID
    /// </summary>
    /// <param name="idAutoRepair">
    ///     The auto repair ID to filter ratings by (optional)
    /// </param>
    /// <returns>
    ///     The list of ratings
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all ratings",
        Description = "Retrieves a list of all ratings"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Ratings retrieved successfully",
        typeof(IEnumerable<RatingResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllRatings([FromQuery] string? idAutoRepair)
    {
        IEnumerable<Rating> ratings;
        
        if (idAutoRepair is null)
        {
            var getAllRatingsQuery = new GetAllRatingsQuery();
            ratings = await ratingQueryService.Handle(getAllRatingsQuery);
        }
        else
        {
            var query = new GetRatingByIdAutoRepairQuery(idAutoRepair);
            ratings = await ratingQueryService.Handle(query);
        }
        
        var ratingResponses = ratings
            .Select(RatingAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(ratingResponses);
    }
    
    /// <summary>
    ///     Get a rating by its ID
    /// </summary>
    /// <param name="id_rating">
    ///     The unique ID of the rating
    /// </param>
    /// <returns>
    ///     The rating response details
    /// </returns>
    [HttpGet("{id_rating}")]
    [SwaggerOperation(
        Summary = "Retrieve a rating by its ID",
        Description = "Retrieves a rating using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Rating retrieved successfully",
        typeof(RatingResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Rating not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetRatingById(string id_rating)
    {
        var getRatingByIdQuery = new GetRatingByIdQuery(id_rating);
        var rating = await ratingQueryService.Handle(getRatingByIdQuery);
        
        if (rating is null) return NotFound();
        
        var ratingResponse = RatingAssembler.ToResponseFromEntity(rating);
        return Ok(ratingResponse);
    }
    
    
    /// <summary>
    ///     Update an existing rating
    /// </summary>
    /// <param name="id_rating">
    ///     The unique ID of the rating to update
    /// </param>
    /// <param name="request">
    ///     The rating update request data
    /// </param>
    /// <returns>
    ///     The updated rating response details
    /// </returns>
    [HttpPut("{id_rating}")]
    [SwaggerOperation(
        Summary = "Update an existing rating",
        Description = "Update an existing rating with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Rating updated successfully",
        typeof(VehicleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Rating not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateRating(string id_rating, [FromBody] UpdateRatingRequest request)
    {
        var updateRatingCommand = RatingAssembler.ToCommandFromRequest(request, id_rating);
        var rating = await ratingCommandService.Handle(updateRatingCommand);
        if (rating is null) return BadRequest();
        
        var ratingResponse = RatingAssembler.ToResponseFromEntity(rating);
        return Ok(ratingResponse);
    }
    
    /// <summary>
    ///     Delete a rating by its ID
    /// </summary>
    /// <param name="id_rating">
    ///     The unique ID of the rating to delete
    /// </param>
    /// <returns>
    ///     No content on successful deletion
    /// </returns>
    [HttpDelete("{id_rating}")]
    [SwaggerOperation(
        Summary = "Delete a rating by its ID",
        Description = "Deletes a rating using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Rating deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid rating ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Rating not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteRating(string id_rating)
    {
        var deleteRatingCommand = new DeleteRatingCommand(id_rating);
        var result = await ratingCommandService.Handle(deleteRatingCommand);
        
        if (!result) return BadRequest();
        
        return NoContent();
    }
}