using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Request to update a vehicle
/// </summary>
/// <param name="Color">
///     The color of the vehicle to be updated
/// </param>
/// <param name="Model">
///     The model of the vehicle to be updated
/// </param>
/// <param name="IdUser">
///     The identifier of the user associated with the vehicle to be updated
/// </param>
/// <param name="VehiclePlate">
///     The license plate of the vehicle to be updated
/// </param>
/// <param name="VehicleBrand">
///     The brand of the vehicle to be updated
/// </param>
/// <param name="VehicleType">
///     The type of the vehicle to be updated
/// </param>
/// <param name="MaintenanceStatus">
///     The maintenance status of the vehicle to be updated
/// </param>
public record UpdateVehicleRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string Color,
    
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Model,
    
    [property: JsonPropertyName("id_user")]
    [Required]
    [MinLength(1)]
    string IdUser,
    
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
    string VehicleType,
    
    [property: JsonPropertyName("maintenance_status")]
    [Required]
    int MaintenanceStatus);