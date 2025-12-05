namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Response model for Location
/// </summary>
/// <param name="Id">
///     The unique identifier of the location
/// </param>
/// <param name="Address">
///     The address of the location
/// </param>
/// <param name="District">
///     The district of the location
/// </param>
/// <param name="Department">
///     The department of the location
/// </param>
public record LocationResponse(
    int Id,
    string Address,
    string District,
    string Department);