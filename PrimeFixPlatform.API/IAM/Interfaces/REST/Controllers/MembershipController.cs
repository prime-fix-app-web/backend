using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Controllers;

/// <summary>
///     REST Controller for Memberships
/// </summary>
/// <param name="membershipQueryService">
///     The membership query service
/// </param>
/// <param name="membershipCommandService">
///     The membership command service
/// </param>
[ApiController]
[Authorize]
[Route("api/v1/memberships")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Memberships Endpoints")]
public class MembershipController(IMembershipQueryService membershipQueryService, IMembershipCommandService membershipCommandService) : ControllerBase
{
    /// <summary>
    ///     Create a new membership
    /// </summary>
    /// <param name="request">
    ///     The create membership request
    /// </param>
    /// <returns>
    ///     A created membership response
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new membership",
        Description = "Creates a new membership with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Membership created successfully",
        typeof(MembershipResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateMembership([FromBody] CreateMembershipRequest request)
    {
        var createMembershipCommand = MembershipAssembler.ToCommandFromRequest(request);
        var membershipId = await membershipCommandService.Handle(createMembershipCommand);
        
        var getMembershipByIdQuery = new GetMembershipByIdQuery(membershipId);
        var membership = await membershipQueryService.Handle(getMembershipByIdQuery);
        
        if (membership is null) return NotFound();
        
        var membershipResponse = MembershipAssembler.ToResponseFromEntity(membership);
        
        return Ok(membershipResponse);
    }
    
    /// <summary>
    ///     Get all memberships
    /// </summary>
    /// <returns>
    ///     The list of memberships
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all memberships",
        Description = "Retrieves a list of all memberships"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Memberships retrieved successfully",
        typeof(IEnumerable<MembershipResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllMemberships()
    {
        var getAllMembershipsQuery = new GetAllMembershipsQuery();
        var memberships = await membershipQueryService.Handle(getAllMembershipsQuery);
        
        var membershipResponses = memberships
            .Select(MembershipAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(membershipResponses);
    }
    
    /// <summary>
    ///     Get a membership by its ID
    /// </summary>
    /// <param name="membership_id">
    ///     The unique identifier of the membership
    /// </param>
    /// <returns>
    ///     A membership response
    /// </returns>
    [HttpGet("{membership_id}")]
    [SwaggerOperation(
        Summary = "Retrieve a membership by its ID",
        Description = "Retrieves a membership using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Membership retrieved successfully",
        typeof(MembershipResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Membership not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetMembershipById([FromRoute] int membership_id)
    {
        var getMembershipByIdQuery = new GetMembershipByIdQuery(membership_id);
        var membership = await membershipQueryService.Handle(getMembershipByIdQuery);
        
        if (membership is null) return NotFound();
        
        var membershipResponse = MembershipAssembler.ToResponseFromEntity(membership);
        
        return Ok(membershipResponse);
    }
    
    /// <summary>
    ///     Update an existing membership
    /// </summary>
    /// <param name="membership_id">
    ///     The unique identifier of the membership
    /// </param>
    /// <param name="request">
    ///     The update membership request
    /// </param>
    /// <returns>
    ///     An updated membership response
    /// </returns>
    [HttpPut("{membership_id}")]
    [SwaggerOperation(
        Summary = "Update an existing membership",
        Description = "Update an existing membership with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Membership updated successfully",
        typeof(MembershipResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Membership not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateMembership([FromRoute] int membership_id, [FromBody] UpdateMembershipRequest request)
    {
        var updateMembershipCommand = MembershipAssembler.ToCommandFromRequest(request, membership_id);
        var membership = await membershipCommandService.Handle(updateMembershipCommand);
        if (membership is null) return BadRequest();
        
        var membershipResponse = MembershipAssembler.ToResponseFromEntity(membership);
        return Ok(membershipResponse);
    }
    
    /// <summary>
    ///     Delete a membership by its ID
    /// </summary>
    /// <param name="membership_id">
    ///     The unique identifier of the membership
    /// </param>
    /// <returns>
    ///     No content
    /// </returns>
    [HttpDelete("{id_membership}")]
    [SwaggerOperation(
        Summary = "Delete a membership by its ID",
        Description = "Deletes a membership using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Membership deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid membership ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Membership not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteMembership([FromRoute] int membership_id)
    {
        var deleteMembershipCommand = new DeleteMembershipCommand(membership_id);
        var result = await membershipCommandService.Handle(deleteMembershipCommand);
        
        if (!result) return BadRequest();
        
        return NoContent();
    }
}