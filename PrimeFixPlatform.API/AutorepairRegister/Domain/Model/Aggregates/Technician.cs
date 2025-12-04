
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;

/// <summary>
///     Technician Aggregate Root
/// </summary>
public partial class Technician
{
    /// <summary>
    ///     Private constructor for ORM
    /// </summary>
    private Technician() { }

    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    /// <param name="name">
    ///     The name of the technician
    /// </param>
    /// <param name="lastName">
    ///     The last name of the technician
    /// </param>
    /// <param name="autoRepairId">
    ///     The unique identifier of the auto repair associated with the technician
    /// </param>
    public Technician( string name, string lastName, int autoRepairId)
    {
        Name = name;
        LastName = lastName;
        AutoRepairId = autoRepairId;
    }
    
    /// <summary>
    ///     Constructor from CreateTechnicianCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the technician
    /// </param>
    public Technician(CreateTechnicianCommand command) : this(
        command.Name,
        command.LastName,
        command.AutoRepairId)
    {
    }
    
    /// <summary>
    ///     Updates the Technician entity with data from the UpdateTechnicianCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to update the technician
    /// </param>
    public void UpdateTechnician(UpdateTechnicianCommand command)
    {
        Name = command.Name;
        LastName = command.LastName;
        AutoRepairId = command.AutoRepairId;
    }
    
    public int TechnicianId { get;  }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public int AutoRepairId { get; private set; }
}