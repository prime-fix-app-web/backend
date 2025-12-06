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
    public Notification( string message, int vehicleId, DateOnly sent)
    {
        Message = message;
        Read = false;
        VehicleId = vehicleId;
        Sent = sent;
    }
    
    /// <summary>
    ///     Constructor from CreateNotificationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the notification
    /// </param>
    public Notification(CreateNotificationCommand command): this(
        command.Message,
        command.VehicleId,
        command.Sent)
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
        Message = command.Message;
        Read = command.Read;
        VehicleId = command.VehicleId;
        Sent = command.Sent;
    }
    
    public int Id { get; private set;  }
    public string Message { get; private set;  }
    public bool Read { get; private set;  }
    
    public Vehicle Vehicle { get; internal set;  }
    public int VehicleId { get; private set;  }
    public DateOnly Sent { get; private set;  }
}