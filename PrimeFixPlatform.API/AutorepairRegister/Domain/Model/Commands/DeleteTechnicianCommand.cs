namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Commands;

/// <summary>
///     Command to delete a Technician
/// </summary>
/// <param name="IdTechnician">
///     The unique identifier for the technician to be deleted
/// </param>
public record DeleteTechnicianCommand(string IdTechnician);