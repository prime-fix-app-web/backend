using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.ValueObjects;

public class ServiceCatalog
{
    private readonly List<ServiceOffer> _serviceOffers;

    public IReadOnlyCollection<ServiceOffer> ServiceOffers => _serviceOffers.AsReadOnly();

    public ServiceCatalog()
    {
        _serviceOffers = new List<ServiceOffer>();
    }
    public ServiceCatalog(List<ServiceOffer> serviceOffers)
    {
        _serviceOffers = serviceOffers;
    }
    
    public void AddServiceOffer(AutoRepair autoRepair, Service service, decimal price, bool isActive, int durationHours)
    {
        var serviceOffer = new ServiceOffer(
            autoRepair.AutoRepairId,
            service,
            price,durationHours,isActive);

        _serviceOffers.Add(serviceOffer);
    }

    public void RemoveServiceOffer(AutoRepair autoRepair, Service service)
    {
        var removed = _serviceOffers.RemoveAll(serviceOffer =>
            serviceOffer.AutoRepair.Equals(autoRepair) && serviceOffer.Service.Equals(service)
        );
        if (removed == 0)
        {
            throw new InvalidOperationException("The service doesn't exist");
        }
    }

    public ServiceOffer GetOfferByServiceId(int serviceId)
    {
        return _serviceOffers
                   .FirstOrDefault(offer => offer.ServiceId == serviceId)
               ?? throw new InvalidOperationException("The service ID doesn't exist");
    }

    public ServiceOffer GetOfferByAutoRepairId(int autoRepairId)
    {
        return _serviceOffers
                   .FirstOrDefault(offer => offer.AutoRepairId == autoRepairId)
               ?? throw new InvalidOperationException("The auto repair doesn't exist");
    }

    public bool IsEmpty()
    {
        return !_serviceOffers.Any();
    }

    public void AddExistingServiceOffer(ServiceOffer offer)
    {
        _serviceOffers.Add(offer);    
    }
}