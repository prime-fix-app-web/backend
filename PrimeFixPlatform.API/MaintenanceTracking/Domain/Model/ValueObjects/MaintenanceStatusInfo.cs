namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

/// <summary>
///     Manages information related to MaintenanceStatus enum values.
/// </summary>
public static class MaintenanceStatusInfo
{
    private static readonly Dictionary<EMaintenanceStatus, string?> NotificationMessages = new()
    {
        { EMaintenanceStatus.NotBeingServiced, null },
        { EMaintenanceStatus.Waiting, "Your vehicle is waiting for maintenance." },
        { EMaintenanceStatus.InDiagnosis, "Your vehicle is currently being diagnosed." },
        { EMaintenanceStatus.InRepair, "Your vehicle is currently under repair." },
        { EMaintenanceStatus.Testing, "Your vehicle is being tested after repairs." },
        { EMaintenanceStatus.ReadyForPickup, "Your vehicle is ready for pickup." },
        { EMaintenanceStatus.Collected, "You have collected your vehicle. Thank you!" }
    };

    /// <summary>
    /// Gets the notification message associated with a MaintenanceStatus value.
    /// </summary>
    public static string? GetNotificationMessage(EMaintenanceStatus status) => NotificationMessages[status];

    /// <summary>
    /// Converts an integer value to its corresponding MaintenanceStatus enum.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the value is invalid.</exception>
    public static EMaintenanceStatus FromValue(int value)
    {
        if (Enum.IsDefined(typeof(EMaintenanceStatus), value))
        {
            return (EMaintenanceStatus)value;
        }
        
        throw new ArgumentException(
            $"[MaintenanceStatus] Invalid value for MaintenanceStatus: {value}"
        );
    }
}