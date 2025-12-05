namespace PrimeFixPlatform.API.IAM.Domain.Model.Commands;

/// <summary>
///     Command to update an existing Location entity.
/// </summary>
/// <param name="LocationId">
///     The unique identifier for the Location to be updated.
/// </param>
/// <param name="Address">
///     The new address of the Location to be updated.
/// </param>
/// <param name="District">
///     The new district where the Location is situated.
/// </param>
/// <param name="Department">
///     The new department where the Location is situated.
/// </param>
public record UpdateLocationCommand(int LocationId, string Address, string District, string Department);