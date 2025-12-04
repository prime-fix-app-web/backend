namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

/// <summary>
///     Command to create a new Technician
/// </summary>
/// <param name="IdTechnician">
///     The unique identifier for the technician to be created
/// </param>
/// <param name="Name">
///     The first name of the technician to be created
/// </param>
/// <param name="LastName">
///     The last name of the technician to be created
/// </param>
/// <param name="IdAutoRepair">
///     The unique identifier of the auto repair shop associated with the technician
/// </param>
public record CreateTechnicianCommand( string Name, string LastName, int AutoRepairId);