using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Handlers;

/// <summary>
    /// Global exception handler for REST controllers.
    /// </summary>
public sealed class GlobalExceptionHandler : IExceptionHandler
{
    /// <summary>
    ///     Handles all unhandled exceptions and maps them to ProblemDetails responses.
    /// </summary>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = CreateProblemDetails(httpContext, exception);

        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/problem+json";

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    /// <summary>
    /// Maps known exception types to HTTP status codes and problem details.
    /// </summary>
    private static ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception)
    {
        var problem = new ProblemDetails
        {
            Instance = httpContext.Request.Path
        };

        switch (exception)
        {
            case ValidationException ex:
                problem.Title = "Validation error";
                problem.Status = StatusCodes.Status400BadRequest;
                problem.Detail = ex.Message;
                break;

            case ArgumentNullException ex:
                problem.Title = "Null argument";
                problem.Status = StatusCodes.Status400BadRequest;
                problem.Detail = ex.Message;
                break;

            case ArgumentException ex:
                problem.Title = "Invalid argument";
                problem.Status = StatusCodes.Status400BadRequest;
                problem.Detail = ex.Message;
                break;

            // 404 - Not found
            case NotFoundIdException ex:
                problem.Title = "Resource not found";
                problem.Status = StatusCodes.Status404NotFound;
                problem.Detail = ex.Message;
                break;
            
            case NotFoundArgumentException ex:
                problem.Title = "Not found";
                problem.Status = StatusCodes.Status404NotFound;
                problem.Detail = ex.Message;
                break;

            // 409 - Conflict
            case ConflictException ex:
                problem.Title = "Conflict";
                problem.Status = StatusCodes.Status409Conflict;
                problem.Detail = ex.Message;
                break;

            // 500 - Internal server error
            default:
                problem.Title = "Internal server error";
                problem.Status = StatusCodes.Status500InternalServerError;
                problem.Detail = "An unexpected error occurred. Please try again later.";
                break;
        }

        // Add trace identifier for correlation
        problem.Extensions["traceId"] = httpContext.TraceIdentifier;

        return problem;
    }
}