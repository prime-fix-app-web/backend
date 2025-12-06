namespace PrimeFixPlatform.API.MaintenanceTracking.Interfaces.ACL;

/// <summary>
///     Interface for the Maintenance Tracking Context Facade
/// </summary>
public interface IMaintenanceTrackingContextFacade
{
    /// <summary>
    ///     Checks if a vehicle exists by its ID
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean value indicating
    /// </returns>
    Task<bool> ExistsVehicleByIdAsync(int vehicleId);
    
    /// <summary>
    ///     Checks if a notification exists by its ID
    /// </summary>
    /// <param name="notificationId">
    ///     The unique identifier of the notification to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean value indicating
    /// </returns>
    Task<bool> ExistsNotificationByIdAsync(int notificationId);

    /// <summary>
    ///     Updates a vehicle's information
    /// </summary>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle to be updated.
    /// </param>
    /// <param name="color">
    ///     The color of the vehicle.
    /// </param>
    /// <param name="model">
    ///     The model of the vehicle.
    /// </param>
    /// <param name="userId">
    ///     The unique identifier of the user associated with the vehicle.
    /// </param>
    /// <param name="vehicleBrand">
    ///     The brand of the vehicle.
    /// </param>
    /// <param name="vehiclePlate">
    ///     The license plate of the vehicle.
    /// </param>
    /// <param name="vehicleType">
    ///     The type of the vehicle.
    /// </param>
    /// <param name="maintenanceStatus">
    ///     The maintenance status of the vehicle.
    /// </param>
    /// <returns></returns>
    Task<int> UpdateVehicleAsync(int vehicleId, string color, string model,
        int userId, string vehicleBrand,
        string vehiclePlate,
        string vehicleType, int maintenanceStatus);
    
    /// <summary>
    ///     Creates a notification
    /// </summary>
    /// <param name="message">
    ///     The message content of the notification to be created.
    /// </param>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle associated with the notification to be created.
    /// </param>
    /// <param name="sent">
    ///     The date the notification was sent.
    /// </param>
    /// <returns></returns>
    Task<int> CreateNotificationAsync(string message, int vehicleId, DateOnly sent);
    
    /// <summary>
    ///     Updates a notification
    /// </summary>
    /// <param name="notificationId">
    ///     The unique identifier of the notification to be updated.
    /// </param>
    /// <param name="read">
    ///     Flag indicating whether the notification has been read.
    /// </param>
    /// <param name="message">
    ///     The message content of the notification to be updated.
    /// </param>
    /// <param name="vehicleId">
    ///     The unique identifier of the vehicle associated with the notification to be updated.
    /// </param>
    /// <param name="sent">
    ///     The date the notification was sent.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the unique identifier
    /// </returns>
    Task<int> UpdateNotificationAsync(int notificationId, bool read,string message, int vehicleId, DateOnly sent);
}