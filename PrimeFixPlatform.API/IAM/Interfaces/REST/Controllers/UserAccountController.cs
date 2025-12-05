using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
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
///     REST controller for managing user accounts
/// </summary>
/// <param name="userAccountQueryService">
///     The service responsible for handling user account queries
/// </param>
/// <param name="userAccountCommandService">
///     The service responsible for handling user account commands
/// </param>
[ApiController]
[Authorize]
[Route("api/v1/user_accounts")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available User Accounts Endpoints")]
public class UserAccountController(IUserAccountQueryService userAccountQueryService, IUserAccountCommandService userAccountCommandService) : ControllerBase
{
    /// <summary>
    ///     Creates a new user account
    /// </summary>
    /// <param name="request">
    ///     The request object containing user account data
    /// </param>
    /// <returns>
    ///     A response indicating the result of the user account creation
    ///     with the created user account details
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new user account",
        Description = "Creates a new user account with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "User Account created successfully",
        typeof(UserAccountResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateUserAccount([FromBody] CreateUserAccountRequest request)
    {
        var createUserAccountCommand = UserAccountAssembler.ToCommandFromRequest(request);
        var userAccountId = await userAccountCommandService.Handle(createUserAccountCommand);
        
        var getUserAccountByIdQuery = new GetUserAccountByIdQuery(userAccountId);
        var userAccount = await userAccountQueryService.Handle(getUserAccountByIdQuery);
        
        if (userAccount is null) return NotFound();
        
        var userAccountResponse = UserAccountAssembler.ToResponseFromEntity(userAccount);
        
        return Ok(userAccountResponse);
    }
    
    /// <summary>
    ///     Gets all user accounts
    /// </summary>
    /// <returns>
    ///     A list of all user accounts
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all user accounts",
        Description = "Retrieves a list of all user accounts"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "User Accounts retrieved successfully",
        typeof(IEnumerable<UserAccountResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllUserAccounts()
    {
        var getAllUserAccountsQuery = new GetAllUserAccountsQuery();
        var userAccounts = await userAccountQueryService.Handle(getAllUserAccountsQuery);
        
        var userAccountResponses = userAccounts
            .Select(UserAccountAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(userAccountResponses);
    }

    /// <summary>
    ///     Gets a user account by its ID
    /// </summary>
    /// <param name="user_account_id">
    ///     The unique ID of the user account to retrieve
    /// </param>
    /// <returns>
    ///     A user account matching the provided ID
    /// </returns>
    [HttpGet("{user_account_id}")]
    [SwaggerOperation(
        Summary = "Retrieve a user account by its ID",
        Description = "Retrieves a user account using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "User retrieved successfully",
        typeof(UserAccountResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "User not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetUserAccountById(int user_account_id)
    {
        var getUserAccountByIdQuery = new GetUserAccountByIdQuery(user_account_id);
        var userAccount = await userAccountQueryService.Handle(getUserAccountByIdQuery);
        
        if (userAccount is null) return NotFound();
        
        var userAccountResponse = UserAccountAssembler.ToResponseFromEntity(userAccount);
        
        return Ok(userAccountResponse);
    }

    /// <summary>
    ///     Updates an existing user account
    /// </summary>
    /// <param name="user_account_id">
    ///     The unique ID of the user account to update
    /// </param>
    /// <param name="request">
    ///     The request object containing updated user account data
    /// </param>
    /// <returns>
    ///     A response indicating the result of the user account update
    /// </returns>
    [HttpPut("{user_account_id}")]
    [SwaggerOperation(
        Summary = "Update an existing user account",
        Description = "Update an existing user account with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "User Account updated successfully",
        typeof(UserAccountResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "User Account not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateUserAccount(int user_account_id,
        [FromBody] UpdateUserAccountRequest request)
    {
        var updateUserAccountCommand = UserAccountAssembler.ToCommandFromRequest(request, user_account_id);
        var userAccount = await userAccountCommandService.Handle(updateUserAccountCommand);
        if (userAccount is null)
        {
            return BadRequest();
        }
        var userAccountResponse = UserAccountAssembler.ToResponseFromEntity(userAccount);
        return Ok(userAccountResponse);
    }
    
    /// <summary>
    ///     Deletes a user account by its ID
    /// </summary>
    /// <param name="user_account_id">
    ///     The unique ID of the user account to delete
    /// </param>
    /// <returns>
    ///     A response indicating the result of the user account deletion
    /// </returns>
    [HttpDelete("{user_account_id}")]
    [SwaggerOperation(
        Summary = "Delete a user account by its ID",
        Description = "Deletes a user account using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "User Account deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid user account ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "User Account not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteUserAccount(int user_account_id)
    {
        var deleteUserAccountCommand = new DeleteUserAccountCommand(user_account_id);
        var result = await userAccountCommandService.Handle(deleteUserAccountCommand);
        
        if (!result)
        {
            return BadRequest();
        }
        
        return NoContent();
    }
}