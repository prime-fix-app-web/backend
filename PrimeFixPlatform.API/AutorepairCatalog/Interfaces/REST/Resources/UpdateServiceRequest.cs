using System.ComponentModel.DataAnnotations;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
/// Request resource used to update an existing service in the auto repair catalog.
/// </summary>
/// <param name="Name">
/// Updated name of the service.
/// This field is required.
/// </param>
/// <param name="Description">
/// Updated description of the service.
/// This field is required.
/// </param>
public record UpdateServiceRequest(
    [Required]
    string Name,
    [Required]
    string Description);