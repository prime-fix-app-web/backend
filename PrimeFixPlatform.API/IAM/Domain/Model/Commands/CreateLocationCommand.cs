using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.IAM.Domain.Model.Commands;

/// <summary>
///     Command to create a new Location entity.
/// </summary>
/// <param name="LocationInformation">
///     The location information value object containing address, district, and department.
/// </param>
public record CreateLocationCommand(LocationInformation LocationInformation);