using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.IAM.Domain.Model.Commands;

/// <summary>
///     Command to update an existing Location entity.
/// </summary>
/// <param name="LocationId">
///     The unique identifier of the location to be updated.
/// </param>
/// <param name="LocationInformation">
///     The location information value object containing address, district, and department.
/// </param>
public record UpdateLocationCommand(int LocationId,LocationInformation LocationInformation);