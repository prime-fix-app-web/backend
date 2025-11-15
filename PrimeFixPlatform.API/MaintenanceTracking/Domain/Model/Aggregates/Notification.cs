using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;

public partial class Notification
{
    private Notification() { }
    
    public Notification(string idNotification, string message, bool read, string idVehicle, DateOnly sent, string idDiagnostic)
    {
        IdNotification = idNotification;
        Message = message;
        Read = read;
        IdVehicle = idVehicle;
        Sent = sent;
        IdDiagnostic = idDiagnostic;
    }
    
    public Notification(CreateNotificationCommand command): this(
        command.IdNotification,
        command.Message,
        command.Read,
        command.IdVehicle,
        command.Sent,
        command.IdDiagnostic)
    {
    }

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