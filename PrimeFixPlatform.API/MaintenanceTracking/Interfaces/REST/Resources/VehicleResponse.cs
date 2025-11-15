using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.REST.Resources;

/// <summary>
///    Response representing a vehicle
/// </summary>
/// <param name="IdVehicle">
///     The unique identifier of the vehicle
/// </param>
/// <param name="Color">
///     The color of the vehicle
/// </param>
/// <param name="Model">
///     The model of the vehicle
/// </param>
/// <param name="IdUser">
///     The unique identifier of the user associated with the vehicle
/// </param>
/// <param name="VehiclePlate">
///     The license plate of the vehicle
/// </param>
/// <param name="VehicleBrand">
///     The brand of the vehicle
/// </param>
/// <param name="VehicleType">
///     The type of the vehicle
/// </param>
/// <param name="MaintenanceStatus">
///     The maintenance status of the vehicle
/// </param>
public record VehicleResponse(
    [property: JsonPropertyName("id_vehicle")] string IdVehicle,
    string Color,
    string Model,
    [property: JsonPropertyName("id_user")] string IdUser,
    [property: JsonPropertyName("vehicle_brand")] string VehicleBrand,
    [property: JsonPropertyName("vehicle_plate")] string VehiclePlate,
    [property: JsonPropertyName("vehicle_type")] string VehicleType,
    [property: JsonPropertyName("maintenance_status")] int MaintenanceStatus);