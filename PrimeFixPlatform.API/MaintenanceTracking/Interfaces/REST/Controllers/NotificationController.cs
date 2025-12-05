using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Controllers;

/// <summary>
///     REST Controller for managing notifications.
/// </summary>
/// <param name="notificationQueryService">
///     The notification query service.
/// </param>
/// <param name="notificationCommandService">
///     The notification command service.
/// </param>
[ApiController]
[Route("api/v1/notifications")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Notifications Endpoints")]
public class NotificationController(INotificationQueryService notificationQueryService, INotificationCommandService notificationCommandService) :  ControllerBase
{
    /// <summary>
    ///     Create a new notification.
    /// </summary>
    /// <param name="request">
    ///     The create notification request.
    /// </param>
    /// <returns>
    ///     The created notification response.
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new notification",
        Description = "Creates a new notification with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Notification created successfully",
        typeof(NotificationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationRequest request)
    {
        var createNotificationCommand = NotificationAssembler.ToCommandFromRequest(request);
        var notificationId = await notificationCommandService.Handle(createNotificationCommand);
        
        /*if (string.IsNullOrWhiteSpace(notificationId)) return BadRequest();*/

        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        var notification = await notificationQueryService.Handle(getNotificationByIdQuery);
        
        if (notification is null) return NotFound();

        var notificationResponse = NotificationAssembler.ToResponseFromEntity(notification);
        return Ok(notificationResponse);
    }
    
    /// <summary>
    ///     Get all notifications.
    /// </summary>
    /// <returns>
    ///     The list of notification responses.
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all notifications",
        Description = "Retrieves a list of all notifications"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Notifications retrieved successfully",
        typeof(IEnumerable<NotificationResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllNotifications()
    {
        var getAllNotificationsQuery = new GetAllNotificationsQuery();
        var notifications = await notificationQueryService.Handle(getAllNotificationsQuery);
        
        var notificationResponses = notifications
            .Select(NotificationAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(notificationResponses);
    }
    
    /// <summary>
    ///     Get a notification by its ID.
    /// </summary>
    /// <param name="notificationId">
    ///     The notification ID.
    /// </param>
    /// <returns>
    ///     The notification response.
    /// </returns>
    [HttpGet("{notificationId}")]
    [SwaggerOperation(
        Summary = "Retrieve a notification by its ID",
        Description = "Retrieves a notification using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Notification retrieved successfully",
        typeof(NotificationResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Notification not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetNotificationById(int notificationId)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        var notification = await notificationQueryService.Handle(getNotificationByIdQuery);
        
        if (notification is null) return NotFound();
        
        var notificationResponse = NotificationAssembler.ToResponseFromEntity(notification);
        return Ok(notificationResponse);
    }
    
    /// <summary>
    ///     Update an existing notification.
    /// </summary>
    /// <param name="notificationId">
    ///     The notification ID.
    /// </param>
    /// <param name="request">
    ///     The update notification request.
    /// </param>
    /// <returns>
    ///     The updated notification response.
    /// </returns>
    [HttpPut("{notificationId}")]
    [SwaggerOperation(
        Summary = "Update an existing notification",
        Description = "Update an existing notification with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Notification updated successfully",
        typeof(NotificationResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Notification not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateNotification(int notificationId, [FromBody] UpdateNotificationRequest request)
    {
        var updateNotificationCommand = NotificationAssembler.ToCommandFromRequest(request, notificationId);
        var updatedNotification = await notificationCommandService.Handle(updateNotificationCommand);
        if (updatedNotification is null) return BadRequest();
        
        var notificationResponse = NotificationAssembler.ToResponseFromEntity(updatedNotification);
        return Ok(notificationResponse);
    }
    
    /// <summary>
    ///     Delete a notification by its ID.
    /// </summary>
    /// <param name="notificationId">
    ///     The notification ID.
    /// </param>
    /// <returns>
    ///     No content result.
    /// </returns>
    [HttpDelete("{notificationId}")]
    [SwaggerOperation(
        Summary = "Delete a notification by its ID",
        Description = "Deletes a notification using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Notification deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid notification ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Notification not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteNotification(int notificationId)
    {
        var deleteNotificationCommand = new DeleteNotificationCommand(notificationId);
        var result = await notificationCommandService.Handle(deleteNotificationCommand);
        
        if (!result) return NotFound();
        
        return NoContent();
    }
}