using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;

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
    public ServiceOffer(int autoRepairId, Service service, decimal price, int durationHours, bool isActive)
    {
        AutoRepairId = autoRepairId;
        ServiceId = service.Id;
        Price = price;
        DurationHours = durationHours;
        IsActive = isActive;
        Service = service;
    }

    /// <summary>
    ///     Updates the price of the service offer
    /// </summary>
    public void UpdatePrice(decimal price)
    {
        Price = price;
    }
    

    public int ServiceOfferId { get; private set; }

    public int AutoRepairId { get; private set; }
    public AutoRepair AutoRepair { get; private set; }
    public int ServiceId { get; private set; }
    public Service Service { get; private set; } 
    public decimal Price { get; private set; }
    
    public int DurationHours { get; set; }
    
    public bool IsActive { get; set; }
    
}