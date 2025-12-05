namespace PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Represents location information including address, district, and department.
/// </summary>
/// <param name="Address">
///     The specific address details.
/// </param>
/// <param name="District">
///     The district where the address is located.
/// </param>
/// <param name="Department">
///     The department associated with the address.
/// </param>
public record LocationInformation(string Address, string District, string Department);