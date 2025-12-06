using Microsoft.AspNetCore.Authentication;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Tokens;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Components;

/**
 * RequestAuthorizationMiddleware is a custom middleware.
 * This middleware is used to authorize requests.
 * It validates a token is included in the request header and that the token is valid.
 * If the token is valid then it sets the user in HttpContext.Items["UserAccount"].
 */
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /**
     * InvokeAsync is called by the ASP.NET Core runtime.
     * It is used to authorize requests.
     * It validates a token is included in the request header and that the token is valid.
     * If the token is valid then it sets the user in HttpContext.Items["UserAccount"].
     */
    public async Task InvokeAsync(
        HttpContext context,
        IUserAccountQueryService userAccountQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        
        var endpoint = context.GetEndpoint();
        // skip authorization if endpoint is decorated with [AllowAnonymous] attribute
        var allowAnonymous = endpoint?.Metadata?.GetMetadata<AllowAnonymousAttribute>() != null;
        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            // [AllowAnonymous] attribute is set, so skip authorization
            await next(context);
            return;
        }
        var path = context.Request.Path;
        // skip authorization for swagger endpoints
        if (path.StartsWithSegments("/swagger") ||
            path.StartsWithSegments("/api-docs") ||
            path.StartsWithSegments("/v1/api-docs"))
        {
            Console.WriteLine("Skipping authorization for Swagger/docs");
            await next(context);
            return;
        }
        
        Console.WriteLine("Entering authorization");
        // get Authorization header
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        
        // check if Authorization header is present and starts with "Bearer "
        if (!string.IsNullOrWhiteSpace(authHeader) &&
            authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            // extract token from Authorization header
            var token = authHeader["Bearer ".Length..].Trim();

            // validate token
            if (!string.IsNullOrWhiteSpace(token))
            {
                try
                {
                    // validate token and get user ID
                    var userId = await tokenService.ValidateToken(token);

                    if (userId != null)
                    {
                        // token is valid, get user account by ID
                        var getUserByIdQuery = new GetUserAccountByIdQuery(userId.Value);
                        var userAccount = await userAccountQueryService.Handle(getUserByIdQuery);

                        // set user account in HttpContext.Items
                        if (userAccount != null)
                        {
                            Console.WriteLine("Token valid, setting HttpContext.Items[\"UserAccount\"]");
                            context.Items["UserAccount"] = userAccount;
                        }
                        else
                        {
                            // this should not happen if token is valid
                            Console.WriteLine("User not found for valid token");
                        }
                    }
                    else
                    {
                        // token is invalid
                        Console.WriteLine("Token validation failed");
                    }
                }
                catch (Exception ex)
                {
                    // log exception
                    Console.WriteLine($"Error validating token: {ex.Message}");
                }
            }
        }
        else
        {
            // no Bearer token found in Authorization header
            Console.WriteLine("No Bearer token found in Authorization header");
        }
        
        // continue to next middleware
        await next(context);
    }
}