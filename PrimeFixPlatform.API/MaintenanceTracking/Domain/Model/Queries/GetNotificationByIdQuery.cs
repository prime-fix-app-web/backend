namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Queries;

/// <summary>
///     Query to get a notification by its identifier.
/// </summary>
/// <param name="IdNotification">
///     The identifier of the notification to retrieve.
/// </param>
public record GetNotificationByIdQuery(string IdNotification);