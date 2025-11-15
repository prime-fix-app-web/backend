using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///     Request to create a vehicle
/// </summary>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle to be created
/// </param>
/// <param name="Color">
///     The color of the vehicle to be created
/// </param>
/// <param name="Model">
///     The model of the vehicle to be created
/// </param>
/// <param name="IdUser">
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
/// <param name="MaintenanceStatus">
///     The maintenance status of the vehicle to be created
/// </param>
public record CreateVehicleRequest(
    [property: JsonPropertyName("id_vehicle")]
    [Required]
    [MinLength(1)]
    string IdVehicle,
    
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