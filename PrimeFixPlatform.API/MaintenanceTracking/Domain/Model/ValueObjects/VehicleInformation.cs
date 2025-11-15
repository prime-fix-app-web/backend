namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

/// <summary>
///     Represents vehicle information including brand, plate, and type.
/// </summary>
/// <param name="VehicleBrand">
///     The brand of the vehicle.
/// </param>
/// <param name="VehiclePlate">
///     The license plate of the vehicle.
/// </param>
/// <param name="VehicleType">
///     The type of the vehicle.
/// </param>
public record VehicleInformation(string VehicleBrand, string VehiclePlate,  string VehicleType);