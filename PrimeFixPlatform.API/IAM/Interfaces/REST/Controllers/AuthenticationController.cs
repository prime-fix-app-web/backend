using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.IAM.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;
using PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/authentication")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Authentication Endpoints")]
public class AuthenticationController(IUserAccountCommandService userAccountCommandService) : ControllerBase
{
    [HttpPost("sign-in")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign in",
        Description = "Sign in as a user account",
        OperationId = "SignIn")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user account was authenticated", typeof(AuthenticatedUserAccountResponse))]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        var signInCommand = AuthenticationAssembler.ToCommandFromRequestSignIn(request);
        var authenticatedUser = await userAccountCommandService.Handle(signInCommand);
        
        
        var userAccountResponse = AuthenticationAssembler.ToResponseFromEntityUserAccount(authenticatedUser.userAccount, authenticatedUser.token);
        return Ok(userAccountResponse);
    }

    [HttpPost("sign-up/vehicle-owner")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign up as Vehicle Owner",
        Description = "Sign up a new user account as Vehicle Owner",
        OperationId = "SignUpVehicleOwner")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user account was created successfully", typeof(UserAccountResponse))]
    
    public async Task<IActionResult> SignUpVehicleOwner([FromBody] VehicleOwnerSignUpRequest request)
    {
        var vehicleOwnerSignUpCommand = AuthenticationAssembler.ToCommandFromRequestSignUpVehicleOwner(request);
        var userAccount = await userAccountCommandService.Handle(vehicleOwnerSignUpCommand);
        
        if (userAccount == null)
        {
            return BadRequest();
        }

        var userAccountResponse = UserAccountAssembler.ToResponseFromEntity(userAccount);
        return StatusCode(StatusCodes.Status201Created, userAccountResponse);
    }   
    
    /// <summary>
    ///     Sign up as Auto Repair
    /// </summary>
    /// <param name="request">
    ///     The auto repair sign-up request containing user details.
    /// </param>
    /// <returns>
    ///     The created user account response.
    /// </returns>
    [HttpPost("sign-up/auto-repair")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign up as Auto Repair",
        Description = "Sign up a new user account as Auto Repair",
        OperationId = "SignUpAutoRepair")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user account was created successfully", typeof(UserAccountResponse))]    
    public async Task<IActionResult> SignUpAutoRepair([FromBody] AutoRepairSignUpRequest request)
    {
        var autoRepairSignUpCommand = AuthenticationAssembler.ToCommandFromRequestSignUpAutoRepair(request);
        var userAccount = await userAccountCommandService.Handle(autoRepairSignUpCommand);
        
        if (userAccount == null)
        {
            return BadRequest();
        }

        var userAccountResponse = UserAccountAssembler.ToResponseFromEntity(userAccount);
        return StatusCode(StatusCodes.Status201Created, userAccountResponse);
    }
}