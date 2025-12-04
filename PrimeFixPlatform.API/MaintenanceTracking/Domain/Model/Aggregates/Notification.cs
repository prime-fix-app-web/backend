using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;

/// <summary>
///     Notification Aggregate Root
/// </summary>
public partial class Notification
{
    /// <summary>
    ///     Private constructor for ORM
    /// </summary>
    private Notification() { }
    
    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    /// <param name="message">
    ///     The content of the notification
    /// </param>
    /// <param name="read">
    ///     The read status of the notification
    /// </param>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle associated with the notification
    /// </param>
    /// <param name="sent">
    ///     The date the notification was sent
    /// </param>
    /// <param name="diagnosticId">
    ///     The unique identifier of the diagnostic associated with the notification
    /// </param>
    public Notification( string message, bool read, int vehicleId, DateOnly sent, int diagnosticId)
    {
        Message = message;
        Read = read;
        VehicleId = vehicleId;
        Sent = sent;
        DiagnosticId = diagnosticId;
    }
    
    /// <summary>
    ///     Constructor from CreateNotificationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the notification
    /// </param>
    public Notification(CreateNotificationCommand command): this(
        command.Message,
        command.Read,
        command.VehicleId,
        command.Sent,
        command.DiagnosticId)
    {
    }

    /// <summary>
    ///     Updates the notification with data from UpdateNotificationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to update the notification
    /// </param>
    public void UpdateNotification(UpdateNotificationCommand command)
    {
        NotificationId = command.NotificationId;
        Message = command.Message;
        Read = command.Read;
        VehicleId = command.VehicleId;
        Sent = command.Sent;
        DiagnosticId = command.DiagnosticId;
    }
    
    public int NotificationId { get; private set;  }
    public string Message { get; private set;  }
    public bool Read { get; private set;  }
    public int VehicleId { get; private set;  }
    public DateOnly Sent { get; private set;  }
    public int DiagnosticId { get; private set;  }
}