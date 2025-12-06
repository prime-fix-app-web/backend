using PrimeFixPlatform.API.MaintenanceTracking.Interfaces.ACL;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.OutboundServices.ACL.Services;

/// <summary>
///     External maintenance tracking service from collection diagnosis
/// </summary>
/// <param name="maintenanceTrackingContextFacade"></param>
public class ExternalMaintenanceTrackingServiceFromCollectionDiagnosis(
    IMaintenanceTrackingContextFacade maintenanceTrackingContextFacade)
    : IExternalMaintenanceTrackingServiceFromCollectionDiagnosis
{
    /// <summary>
    ///     Checks if a vehicle exists by its ID.
    /// </summary>
    /// <param name="vehicleId">
    ///     The ID of the vehicle to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains true if the vehicle exists; otherwise, false.
    /// </returns>
    public async Task<bool> ExitsVehicleByIdAsync(int vehicleId)
    {
        return await maintenanceTrackingContextFacade.ExistsVehicleByIdAsync(vehicleId);
    }

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
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the ID of the created notification.
    /// </returns>
    public async Task<int> CreateNotificationAsync(string message, int vehicleId, DateOnly sent)
    {
        return await maintenanceTrackingContextFacade.CreateNotificationAsync(message, vehicleId, sent);
    }
}