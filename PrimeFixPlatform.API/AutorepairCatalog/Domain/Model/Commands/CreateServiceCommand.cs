namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
/// <summary>
///     Command to create a new Service
/// </summary>
/// <param name="Name">
///     The name of the service
/// </param>
/// <param name="Description">
///     The description of the service
/// </param>
public record CreateServiceCommand(string Name, string Description);