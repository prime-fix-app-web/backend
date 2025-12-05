using System.ComponentModel.DataAnnotations;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Request to create a new location
/// </summary>
/// <param name="Address">
///     The address of the location to be created
/// </param>
/// <param name="District">
///     The district where the location is situated
/// </param>
/// <param name="Department">
///     The department where the location is situated
/// </param>
public record CreateLocationRequest(
    
    [Required]
    [MaxLength(100)]
    string Address,
    
    [Required]
    [MaxLength(50)]
    string District,
    
    [Required]
    [MaxLength(50)]
    string Department);