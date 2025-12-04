namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to delete a location by its identifier.
/// </summary>
/// <param name="LocationId">
///     The identifier of the location to be deleted.
/// </param>
public record DeleteLocationCommand(int LocationId);