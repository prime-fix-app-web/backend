using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.ValueObjects;

public class ServiceCatalog
{
    
    
    private readonly List<ServiceOffer> _serviceOffers;

    public IReadOnlyCollection<ServiceOffer> ServiceOffers => _serviceOffers.AsReadOnly();

    public ServiceCatalog()
    {
        _serviceOffers = new List<ServiceOffer>();
    }
    
    public void AddServiceOffer(AutoRepair autoRepair, Service service, decimal price)
    {
        var serviceOffer = new ServiceOffer(
            autoRepair.IdAutoRepair,
            service.Id,
            price);

        _serviceOffers.Add(serviceOffer);
    }

    public ServiceOffer GetOfferByServiceId(int serviceId)
    {
        return _serviceOffers
                   .FirstOrDefault(offer => offer.IdService == serviceId)
               ?? throw new InvalidOperationException("The service ID doesn't exist");
    }

    public ServiceOffer GetOfferByAutoRepairId(int autoRepairId)
    {
        return _serviceOffers
                   .FirstOrDefault(offer => offer.IdAutoRepair == autoRepairId)
               ?? throw new InvalidOperationException("The auto repair doesn't exist");
    }

    public bool IsEmpty()
    {
        return !_serviceOffers.Any();
    }
}