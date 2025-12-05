using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Controllers;

/// <summary>
///     Controller for managing roles within the IAM system
/// </summary>
/// <param name="roleQueryService">
///     The service responsible for handling role queries
/// </param>
[ApiController]
[Route("api/v1/roles")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available ERole Endpoints")]
public class RoleController(IRoleQueryService roleQueryService): ControllerBase
{

    /// <summary>
    ///     Get all roles
    /// </summary>
    /// <returns>
    ///     The list of all roles
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all roles",
        Description = "Retrieves a list of all roles"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "ERole retrieved successfully",
        typeof(IEnumerable<RoleResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllRoles()
    {
        var getAllRolesQuery = new GetAllRolesQuery();
        var roles = await roleQueryService.Handle(getAllRolesQuery);

        var roleResponses = roles
            .Select(RoleAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(roleResponses);
    }
}