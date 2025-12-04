namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to update an existing service
/// </summary>
/// <param name="ServiceId">
///     The ID of the service to be updated
/// </param>
/// <param name="Name">
///     The name of the service to be updated
/// </param>
/// <param name="Description">
///     The description of the sevrice to be updated
/// </param>
public record UpdateServiceCommand(int ServiceId, string Name, string Description);