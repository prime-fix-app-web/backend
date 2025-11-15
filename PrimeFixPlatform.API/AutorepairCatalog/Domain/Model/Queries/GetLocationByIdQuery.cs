namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

/// <summary>
///     Query to get a location by its identifier.
/// </summary>
/// <param name="IdLocation">
///     The identifier of the location to retrieve.
/// </param>
public record GetLocationByIdQuery(string IdLocation);