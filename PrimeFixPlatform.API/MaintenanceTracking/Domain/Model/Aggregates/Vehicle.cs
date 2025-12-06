using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Commands;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;

/// <summary>
///     Vehicle aggregate root entity
/// </summary>
public partial class Vehicle
{
    /// <summary>
    ///     Private constructor for ORM and serialization purposes
    /// </summary>
    private Vehicle() { }
    
    /// <summary>
    ///     The constructor for the Vehicle aggregate root entity.
    /// </summary>
    /// <param name="color">
    ///     The color of the vehicle.
    /// </param>
    /// <param name="model">
    ///     The model of the vehicle.
    /// </param>
    /// <param name="userId">
    ///     The identifier of the user associated with the vehicle.
    /// </param>
    /// <param name="vehicleInformation">
    ///     The information associated with the vehicle.
    /// </param>
    public Vehicle( string color, string model, int userId,
        VehicleInformation vehicleInformation)
    {
        Color = color;
        Model = model;
        UserId = userId;
        VehicleInformation = vehicleInformation;
        MaintenanceStatus = EMaintenanceStatus.NotBeingServiced;
    }
    
    /// <summary>
    ///     Constructor for the Vehicle aggregate root entity from CreateVehicleCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing data to create a Vehicle
    /// </param>
    public Vehicle(CreateVehicleCommand command): this(
        command.Color,
        command.Model,
        command.UserId,
        command.VehicleInformation)
    {
    }

    /// <summary>
    ///     Update the vehicle details based on the UpdateVehicleCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing updated data for the Vehicle
    /// </param>
    public void UpdateVehicle(UpdateVehicleCommand command)
    {
        Color = command.Color;
        Model = command.Model;
        UserId = command.UserId;
        VehicleInformation = command.VehicleInformation;
        MaintenanceStatus = command.MaintenanceStatus;
    }
    
    public int Id { get; private set; }
    
    public string Color { get; private set; }
    
    public string Model { get; private set; }
    
    public int UserId { get; private set; }
    
    public VehicleInformation VehicleInformation { get; private set; }
    
    public EMaintenanceStatus MaintenanceStatus { get; private set; }
}