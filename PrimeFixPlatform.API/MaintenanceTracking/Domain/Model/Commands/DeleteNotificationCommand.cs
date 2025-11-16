namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to delete a notification by its identifier.
/// </summary>
/// <param name="IdNotification">
///     The identifier of the notification to be deleted.
/// </param>
public record DeleteNotificationCommand(string IdNotification);