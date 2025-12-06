using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Request to create a vehicle
/// </summary>
/// <param name="Color">
///     The color of the vehicle to be created
/// </param>
/// <param name="Model">
///     The model of the vehicle to be created
/// </param>
/// <param name="UserId">
///     The identifier of the user associated with the vehicle to be created
/// </param>
/// <param name="VehiclePlate">
///     The license plate of the vehicle to be created
/// </param>
/// <param name="VehicleBrand">
///     The brand of the vehicle to be created
/// </param>
/// <param name="VehicleType">
///     The type of the vehicle to be created
/// </param>
public record CreateVehicleRequest(
    
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string Color,
    
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Model,
    
    [property: JsonPropertyName("user_id")]
    [Required]
    int UserId,
    
    [property: JsonPropertyName("vehicle_brand")]
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string VehicleBrand,
    
    [property: JsonPropertyName("vehicle_plate")]
    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    string VehiclePlate,
    
    [property: JsonPropertyName("vehicle_type")]
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string VehicleType);