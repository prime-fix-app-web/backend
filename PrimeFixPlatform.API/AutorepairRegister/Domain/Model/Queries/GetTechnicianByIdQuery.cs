namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Queries;

/// <summary>
///     Query to get a Technician by its unique identifier
/// </summary>
/// <param name="IdTechnician">
///     The unique identifier of the technician to be retrieved
/// </param>
public record GetTechnicianByIdQuery(string IdTechnician);