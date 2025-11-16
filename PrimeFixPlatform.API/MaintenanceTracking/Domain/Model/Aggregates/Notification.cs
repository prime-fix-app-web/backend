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
    /// <param name="idNotification">
    ///     The unique identifier of the notification
    /// </param>
    /// <param name="message">
    ///     The content of the notification
    /// </param>
    /// <param name="read">
    ///     The read status of the notification
    /// </param>
    /// <param name="idVehicle">
    ///     The unique identifier of the vehicle associated with the notification
    /// </param>
    /// <param name="sent">
    ///     The date the notification was sent
    /// </param>
    /// <param name="idDiagnostic">
    ///     The unique identifier of the diagnostic associated with the notification
    /// </param>
    public Notification(string idNotification, string message, bool read, string idVehicle, DateOnly sent, string idDiagnostic)
    {
        IdNotification = idNotification;
        Message = message;
        Read = read;
        IdVehicle = idVehicle;
        Sent = sent;
        IdDiagnostic = idDiagnostic;
    }
    
    /// <summary>
    ///     Constructor from CreateNotificationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the notification
    /// </param>
    public Notification(CreateNotificationCommand command): this(
        command.IdNotification,
        command.Message,
        command.Read,
        command.IdVehicle,
        command.Sent,
        command.IdDiagnostic)
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
        IdVehicle = command.IdVehicle;
        Sent = command.Sent;
        IdDiagnostic = command.IdDiagnostic;
    }
    
    public string IdNotification { get; private set;  }
    public string Message { get; private set;  }
    public bool Read { get; private set;  }
    public string IdVehicle { get; private set;  }
    public DateOnly Sent { get; private set;  }
    public string IdDiagnostic { get; private set;  }
}