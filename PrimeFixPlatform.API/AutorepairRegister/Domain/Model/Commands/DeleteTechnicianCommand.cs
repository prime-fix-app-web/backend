namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

/// <summary>
///     Command to delete a Technician
/// </summary>
/// <param name="TechnicianId">
///     The unique identifier for the technician to be deleted
/// </param>
public record DeleteTechnicianCommand(int TechnicianId);