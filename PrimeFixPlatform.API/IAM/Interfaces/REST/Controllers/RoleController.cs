using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/roles")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Roles Endpoints")]
public class RoleController(IRoleQueryService roleQueryService, IRoleCommandService roleCommandService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new role",
        Description = "Creates a new role with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Role created successfully",
        typeof(RoleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
    {
        var createRoleCommand = RoleAssembler.ToCommandFromRequest(request);
        var roleId = await roleCommandService.Handle(createRoleCommand);

        if (string.IsNullOrWhiteSpace(roleId)) return BadRequest();

        var getRoleByIdQuery = new GetRoleByIdQuery(roleId);
        var role = await roleQueryService.Handle(getRoleByIdQuery);
        
        if (role is null) return NotFound();
        
        var roleResponse = RoleAssembler.ToResponseFromEntity(role);

        return Ok(roleResponse);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all roles",
        Description = "Retrieves a list of all roles"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Roles retrieved successfully",
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

    [HttpGet("{id_role}")]
    [SwaggerOperation(
        Summary = "Retrieve a role by its ID",
        Description = "Retrieves a role using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Role retrieved successfully",
        typeof(RoleResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Role not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetRoleById(string id_role)
    {
        var getRoleByIdQuery = new GetRoleByIdQuery(id_role);
        var role = await roleQueryService.Handle(getRoleByIdQuery);
        
        if (role is null) return NotFound();
        
        var roleResponse = RoleAssembler.ToResponseFromEntity(role);
        
        return Ok(roleResponse);
    }

    [HttpPut("{id_role}")]
    [SwaggerOperation(
        Summary = "Update an existing role",
        Description = "Update an existing role with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Role updated successfully",
        typeof(RoleResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Role not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateRole(string id_role, [FromBody] UpdateRoleRequest request)
    {
        var updateRoleCommand = RoleAssembler.ToCommandFromRequest(request, id_role);
        var role = await roleCommandService.Handle(updateRoleCommand);
        if (role is null) return BadRequest();
        
        var roleResponse = RoleAssembler.ToResponseFromEntity(role);
        return Ok(roleResponse);
    }
    
    [HttpDelete("{id_role}")]
    [SwaggerOperation(
        Summary = "Delete a role by its ID",
        Description = "Deletes a role using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Role deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid role ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Role not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteRole(string id_role)
    {
        var deleteRoleCommand = new DeleteRoleCommand(id_role);
        var result = await roleCommandService.Handle(deleteRoleCommand);
        
        if (!result) return BadRequest();
        
        return NoContent();
    }
}