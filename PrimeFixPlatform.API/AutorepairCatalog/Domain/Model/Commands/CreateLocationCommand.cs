namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

/// <summary>
///     Command to create a new Location entity.
/// </summary>
/// <param name="IdLocation">
///     The unique identifier for the Location to be created.
/// </param>
/// <param name="Address">
///     The address of the Location to be created.
/// </param>
/// <param name="District">
///     The district where the Location is situated.
/// </param>
/// <param name="Department">
///     The department where the Location is situated.
/// </param>
public record CreateLocationCommand(int IdLocation, string Address, string District, string Department);