using System.ComponentModel.DataAnnotations;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

/// <summary>
///     Request to update a location
/// </summary>
/// <param name="Address">
///     The address of the location to update
/// </param>
/// <param name="District">
///     The district of the location to update
/// </param>
/// <param name="Department">
///     The department of the location to update
/// </param>
public record UpdateLocationRequest(
    [Required]
    [MaxLength(100)]
    string Address,
    
    [Required]
    [MaxLength(50)]
    string District,
    
    [Required]
    [MaxLength(50)]
    string Department);