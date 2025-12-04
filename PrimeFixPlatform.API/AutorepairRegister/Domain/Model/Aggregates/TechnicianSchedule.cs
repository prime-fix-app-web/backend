using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;

/// <summary>
///     TechnicianSchedule Aggregate Root
/// </summary>
public partial class TechnicianSchedule
{
    /// <summary>
    ///     Private constructor for ORM and serialization purposes
    /// </summary>
    private TechnicianSchedule() { }
    
    /// <summary>
    ///     Constructor with all properties
    /// </summary>
    /// <param name="idSchedule">
    ///     The unique identifier for the technician schedule
    /// </param>
    /// <param name="idTechnician">
    ///     The unique identifier for the technician
    /// </param>
    /// <param name="dayOfWeek">
    ///     The day of the week for the schedule
    /// </param>
    /// <param name="startTime">
    ///     The start time of the schedule
    /// </param>
    /// <param name="endTime">
    ///     The end time of the schedule
    /// </param>
    /// <param name="isActive">
    ///     Flag indicating if the schedule is active
    /// </param>
    public TechnicianSchedule( int technicianId, string dayOfWeek, TimeOnly startTime, TimeOnly endTime, bool isActive)
    {
        TechnicianId = technicianId;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        IsActive = isActive;
    }
    
    /// <summary>
    ///     Constructor from CreateTechnicianScheduleCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create a TechnicianSchedule
    /// </param>
    public TechnicianSchedule(CreateTechnicianScheduleCommand command) : this(
        command.TechnicianId,
        command.DayOfWeek,
        command.StartTime,
        command.EndTime,
        command.IsActive)
    {
    }
    
    /// <summary>
    ///     Updates the TechnicianSchedule properties based on the provided command
    /// </summary>
    /// <param name="command">
    ///     The command containing the updated data for the TechnicianSchedule
    /// </param>
    public void UpdateTechnicianSchedule(UpdateTechnicianScheduleCommand command)
    {
        TechnicianId = command.TechnicianId;
        DayOfWeek = command.DayOfWeek;
        StartTime = command.StartTime;
        EndTime = command.EndTime;
        IsActive = command.IsActive;
    }
    
    public int ScheduleId { get; private set; }
    
    public int TechnicianId { get; private set; }
    public string DayOfWeek { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public bool IsActive { get; private set; }
}