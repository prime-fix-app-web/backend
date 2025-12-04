using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to create a new Vehicle
/// </summary>
/// <param name="Color">
///     The color of the vehicle to be created
/// </param>
/// <param name="Model">
///     The model of the vehicle to be created
/// </param>
/// <param name="UserId">
///     The unique identifier of the user associated with the vehicle to be created
/// </param>
/// <param name="VehicleInformation">
///     The detailed information about the vehicle to be created
/// </param>
/// <param name="MaintenanceStatus">
///     The maintenance status of the vehicle to be created
/// </param>
public record CreateVehicleCommand( string Color, string Model, int UserId,
    VehicleInformation VehicleInformation, int MaintenanceStatus);