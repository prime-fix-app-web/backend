using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;

/// <summary>
///     Aggregate root representing a service offer provided by an auto repair shop.
/// </summary>
public class ServiceOffer
{
    /// <summary>
    ///     Private constructor for ServiceOffer
    /// </summary>
    private ServiceOffer() { }

    /// <summary>
    ///     Constructor for Service Offer
    /// </summary>
    /// <param name="autoRepairId">The Auto Repair ID</param>
    /// <param name="serviceId"> The Service ID</param>
    /// <param name="price">The price of service </param>
    /// <param name="durationHours">The duration of the service</param>
    /// <param name="isActive">The state of the service </param>
    public ServiceOffer(int autoRepairId, int serviceId, decimal price, int durationHours, bool isActive)
    {
        AutoRepairId = autoRepairId;
        ServiceId = serviceId;
        Price = price;
        DurationHours = durationHours;
        IsActive = isActive;
    }

    /// <summary>
    ///     Updates the price of the service offer
    /// </summary>
    public void UpdatePrice(decimal price)
    {
        Price = price;
    }
    

    public int Id { get; private set; }

    public int AutoRepairId { get; private set; }
    public AutoRepair AutoRepair { get; private set; } = null!;
    public int ServiceId { get; private set; }
    public Service Service { get; private set; } = null!;
    public decimal Price { get; private set; }
    
    public int DurationHours { get; set; }
    
    public bool IsActive { get; set; }
    
}