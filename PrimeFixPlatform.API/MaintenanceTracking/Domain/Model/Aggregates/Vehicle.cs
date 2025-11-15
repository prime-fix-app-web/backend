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
    /// <param name="idVehicle">
    ///     The unique identifier for the vehicle.
    /// </param>
    /// <param name="color">
    ///     The color of the vehicle.
    /// </param>
    /// <param name="model">
    ///     The model of the vehicle.
    /// </param>
    /// <param name="idUser">
    ///     The identifier of the user associated with the vehicle.
    /// </param>
    /// <param name="vehicleInformation">
    ///     The information associated with the vehicle.
    /// </param>
    /// <param name="maintenanceStatus">
    ///     The maintenance status of the vehicle.
    /// </param>
    public Vehicle(string idVehicle, string color, string model, string idUser,
        VehicleInformation vehicleInformation, int maintenanceStatus)
    {
        IdVehicle = idVehicle;
        Color = color;
        Model = model;
        IdUser = idUser;
        VehicleInformation = vehicleInformation;
        MaintenanceStatus = maintenanceStatus;
    }
    
    /// <summary>
    ///     Constructor for the Vehicle aggregate root entity from CreateVehicleCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing data to create a Vehicle
    /// </param>
    public Vehicle(CreateVehicleCommand command): this(
        command.IdVehicle,
        command.Color,
        command.Model,
        command.IdUser,
        command.VehicleInformation,
        command.MaintenanceStatus)
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
        IdUser = command.IdUser;
        VehicleInformation = command.VehicleInformation;
        MaintenanceStatus = command.MaintenanceStatus;
    }
    
    public string IdVehicle { get; private set; }
    
    public string Color { get; private set; }
    
    public string Model { get; private set; }
    
    public string IdUser { get; private set; }
    
    public VehicleInformation VehicleInformation { get; private set; }
    
    public int MaintenanceStatus { get; private set; }
}