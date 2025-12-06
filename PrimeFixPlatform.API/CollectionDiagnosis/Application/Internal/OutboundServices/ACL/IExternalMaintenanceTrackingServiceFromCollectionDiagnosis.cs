namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Interface for external maintenance tracking service from collection diagnosis
/// </summary>
public interface IExternalMaintenanceTrackingServiceFromCollectionDiagnosis
{
    /// <summary>
    ///     Checks if a vehicle exists by its ID.
    /// </summary>
    /// <param name="vehicleId">
    ///     The ID of the vehicle to check.
    /// </param>
    /// <returns>
    ///     The task result containing true if the vehicle exists; otherwise, false.
    /// </returns>
    Task<bool> ExitsVehicleByIdAsync(int vehicleId);
    
    /// <summary>
    ///     Creates a notification for a vehicle.
    /// </summary>
    /// <param name="message">
    ///     The notification message.
    /// </param>
    /// <param name="vehicleId">
    ///     The ID of the vehicle.
    /// </param>
    /// <param name="sent">
    ///     The date the notification was sent.
    /// </param>
    /// <returns></returns>
    Task<int> CreateNotificationAsync(string message, int vehicleId, DateOnly sent);
}