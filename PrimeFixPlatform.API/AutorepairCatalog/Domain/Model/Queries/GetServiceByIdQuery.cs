namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Queries;

/// <summary>
///     Query object representing a request to retrieve a Service entity
///     by its unique identifier.
/// </summary>
/// <param name="ServiceId">
///     The unique identifier of the Service to retrieve.
/// </param>
public record GetServiceByIdQuery(int ServiceId);