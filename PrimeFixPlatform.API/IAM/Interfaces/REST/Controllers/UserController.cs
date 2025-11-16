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

/// <summary>
///     REST Controller for User aggregate
/// </summary>
/// <param name="userQueryService">
///     The user query service
/// </param>
/// <param name="userCommandService">
///     The user command service
/// </param>
[ApiController]
[Route("api/v1/users")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Users Endpoints")]
public class UserController(IUserQueryService userQueryService, IUserCommandService userCommandService): ControllerBase
{

    /// <summary>
    ///     Creates a new user
    /// </summary>
    /// <param name="request">
    ///     Request body containing the user data
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result
    ///     contains the IActionResult with the created user data or an error response.
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new user",
        Description = "Creates a new user with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "User created successfully",
        typeof(UserResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var createUserCommand = UserAssembler.ToCommandFromRequest(request);
        var userId = await userCommandService.Handle(createUserCommand);
        
        if (string.IsNullOrWhiteSpace(userId)) return BadRequest();
        
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        
        if (user is null) return NotFound();
        
        var userResponse = UserAssembler.ToResponseFromEntity(user);
        
        return Ok(userResponse);
    }
    
    /// <summary>
    ///     Gets all users
    /// </summary>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result
    ///     contains the IActionResult with the list of users.
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all users",
        Description = "Retrieves a list of all users"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Users retrieved successfully",
        typeof(IEnumerable<UserResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);

        var userResponses = users
            .Select(UserAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(userResponses);
    }
    
    /// <summary>
    ///     Gets a user by its ID
    /// </summary>
    /// <param name="id_user">
    ///     The ID of the user to retrieve
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result
    ///     contains the IActionResult with the user data or an error response.
    /// </returns>
    [HttpGet("{id_user}")]
    [SwaggerOperation(
        Summary = "Retrieve a user by its ID",
        Description = "Retrieves a user using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "User retrieved successfully",
        typeof(UserResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "User not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetUserById(string id_user)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id_user);
        var user = await userQueryService.Handle(getUserByIdQuery);
        
        if (user is null) return NotFound();
        
        var userResponse = UserAssembler.ToResponseFromEntity(user);
        
        return Ok(userResponse);
    }
    
    
    /// <summary>
    ///     Updates an existing user
    /// </summary>
    /// <param name="id_user">
    ///     The ID of the user to update
    /// </param>
    /// <param name="request">
    ///     The request body containing the updated user data
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result
    ///     contains the IActionResult with the updated user data or an error response.
    /// </returns>
    [HttpPut("{id_user}")]
    [SwaggerOperation(
        Summary = "Update an existing user",
        Description = "Update an existing user with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "User updated successfully",
        typeof(UserResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
            "User not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateUser(string id_user, [FromBody] UpdateUserRequest request)
    {
        var updateUserCommand = UserAssembler.ToCommandFromRequest(request, id_user);
        var user = await userCommandService.Handle(updateUserCommand);
        if (user is null)
        {
            return BadRequest();
        }

        var userResponse = UserAssembler.ToResponseFromEntity(user);
        return Ok(userResponse);
    }

    /// <summary>
    ///    Deletes an existing user
    /// </summary>
    /// <param name="id_user">
    ///     The ID of the user to delete
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result
    ///     contains the IActionResult indicating the result of the delete operation.
    /// </returns>
    [HttpDelete("{id_user}")]
    [SwaggerOperation(
        Summary = "Delete a user by its ID",
        Description = "Deletes a user using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "User deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid user ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "User not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteUser(string id_user)
    {
        var deleteUserCommand = new DeleteUserCommand(id_user);
        var result = await userCommandService.Handle(deleteUserCommand);
        if (!result)
        {
            return BadRequest();
        }
        return NoContent();
    }
}