using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Handlers;

/// <summary>
///     Global exception handler for REST controllers.
/// </summary>
public sealed class GlobalExceptionHandler : IExceptionHandler
{
    /// <summary>
    ///     Tries to handle the given exception and write an appropriate response to the HTTP context.
    /// </summary>
    /// <param name="httpContext">
    ///     Context of the HTTP request
    /// </param>
    /// <param name="exception">
    ///     The exception to handle
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns></returns>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, responseBody) = MapExceptionToResponse(httpContext, exception);

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(responseBody, cancellationToken);

        return true;
    }

    /// <summary>
    ///     Maps exceptions to appropriate HTTP status codes and response bodies.
    /// </summary>
    /// <param name="httpContext">
    ///     Context of the HTTP request
    /// </param>
    /// <param name="exception">
    ///     The exception to map
    /// </param>
    /// <returns>
    ///     A tuple containing the HTTP status code and the response body object.
    /// </returns>
    private static (int StatusCode, object Response) MapExceptionToResponse(
        HttpContext httpContext,
        Exception exception)
    {
        // 400 - Bad request
        if (exception is ValidationException validationEx)
        {
            var dto = new BadRequestResponse
            {
                Status = StatusCodes.Status400BadRequest,
                Error = "BAD_REQUEST",
                Message = validationEx.Message,
                Errors = new Dictionary<string, string[]>
                {
                    { "validation", new[] { validationEx.Message } }
                }
            };
            return (StatusCodes.Status400BadRequest, dto);
        }

        // 400 - Bad request
        if (exception is ArgumentNullException argNullEx)
        {
            var dto = new BadRequestResponse
            {
                Status = StatusCodes.Status400BadRequest,
                Error = "BAD_REQUEST",
                Message = "Null argument received.",
                Errors = new Dictionary<string, string[]>
                {
                    { argNullEx.ParamName ?? "argument", new[] { argNullEx.Message } }
                }
            };
            return (StatusCodes.Status400BadRequest, dto);
        }

        // 400 - Bad request
        if (exception is ArgumentException argEx)
        {
            var dto = new BadRequestResponse
            {
                Status = StatusCodes.Status400BadRequest,
                Error = "BAD_REQUEST",
                Message = "Invalid argument.",
                Errors = new Dictionary<string, string[]>
                {
                    { argEx.ParamName ?? "argument", new[] { argEx.Message } }
                }
            };
            return (StatusCodes.Status400BadRequest, dto);
        }

        // 404 - Not found
        if (exception is NotFoundIdException notFoundIdEx)
        {
            var dto = new NotFoundResponse
            {
                Status = StatusCodes.Status404NotFound,
                Error = "NOT_FOUND",
                Message = notFoundIdEx.Message
            };
            return (StatusCodes.Status404NotFound, dto);
        }

        if (exception is NotFoundArgumentException notFoundArgEx)
        {
            var dto = new NotFoundResponse
            {
                Status = StatusCodes.Status404NotFound,
                Error = "NOT_FOUND",
                Message = notFoundArgEx.Message
            };
            return (StatusCodes.Status404NotFound, dto);
        }

        // 409 - Conflict
        if (exception is ConflictException conflictEx)
        {
            var dto = new ConflictResponse
            {
                Status = StatusCodes.Status409Conflict,
                Error = "CONFLICT",
                Message = conflictEx.Message
            };
            return (StatusCodes.Status409Conflict, dto);
        }

        // 500 - Internal server error (default)
        var internalDto = new InternalServerErrorResponse
        {
            Status = StatusCodes.Status500InternalServerError,
            Error = "INTERNAL_SERVER_ERROR",
            Message = "An unexpected error occurred. Please try again later."
        };

        return (StatusCodes.Status500InternalServerError, internalDto);
    }
}