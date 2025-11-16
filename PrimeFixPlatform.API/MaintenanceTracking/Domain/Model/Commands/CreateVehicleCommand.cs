using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;

/// <summary>
///     Command to create a new Vehicle
/// </summary>
/// <param name="IdVehicle">
///     The unique identifier for the vehicle to be created
/// </param>
/// <param name="Color">
///     The color of the vehicle to be created
/// </param>
/// <param name="Model">
///     The model of the vehicle to be created
/// </param>
/// <param name="IdUser">
///     The unique identifier of the user associated with the vehicle to be created
/// </param>
/// <param name="VehicleInformation">
///     The detailed information about the vehicle to be created
/// </param>
/// <param name="MaintenanceStatus">
///     The maintenance status of the vehicle to be created
/// </param>
public record CreateVehicleCommand(string IdVehicle, string Color, string Model, string IdUser,
    VehicleInformation VehicleInformation, int MaintenanceStatus);