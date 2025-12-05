using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;

/// <summary>
///     AutoRepair Aggregate Root
/// </summary>
public partial class AutoRepair
{
    /// <summary>
    ///     Gets the collection of service offers associated with this AutoRepair.
    /// </summary>

    public virtual ICollection<ServiceOffer> ServiceOffers { get; private set; } = new List<ServiceOffer>();
    
    /// <summary>
    ///     Provides a value object representation of the service catalog
    ///     containing the current ServiceOffers.
    /// </summary>
    public ServiceCatalog ServiceCatalog => new(ServiceOffers.ToList());

    /// <summary>
    ///     Private parameterless constructor required by EF Core.
    /// </summary>
    protected AutoRepair() { } 

    /// <summary>
    ///     Initializes a new instance of <see cref="AutoRepair"/> with the specified details.
    /// </summary>
    /// <param name="ruc">The RUC (tax ID) of the auto repair.</param>
    /// <param name="contactEmail">The contact email of the auto repair.</param>
    /// <param name="userAccountId">The associated user account ID.</param>
    public AutoRepair(string ruc, string contactEmail, int userAccountId)
    {
        Ruc = ruc;
        ContactEmail = contactEmail;
        TechniciansCount = 0;
        UserAccountId = userAccountId;
    }

    public AutoRepair(CreateAutoRepairCommand command)
        : this(command.Ruc, command.ContactEmail, command.UserAccountId)
    { }

    public void UpdateAutoRepair(UpdateAutoRepairCommand command)
    {
        Ruc = command.Ruc;
        ContactEmail = command.ContactEmail;
        UserAccountId = command.UserAccountId;
    }
    
    /// <summary>
    ///     Increments the count of technicians associated with this AutoRepair.
    /// </summary>
    public void IncrementTechniciansCount()
    {
        TechniciansCount++;
    }
    
    /// <summary>
    ///     Decrements the count of technicians associated with this AutoRepair.
    /// </summary>
    public void DecrementTechniciansCount()
    {
        if (TechniciansCount > 0)
        {
            TechniciansCount--;
        }
    }

    public int AutoRepairId { get; private set; }
    public string Ruc { get; private set; }
    public string ContactEmail { get; private set; }
    public int TechniciansCount { get; private set; }
    public int UserAccountId { get; private set; }
    
    /// <summary>
    ///     Registers a new service offer for this AutoRepair.
    /// </summary>
    /// <param name="service">The service to register.</param>
    /// <param name="price">The price of the service.</param>
    /// <param name="durationHours">The duration of the service in hours.</param>
    /// <param name="isActive">Indicates whether the service offer is active.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="service"/> is null.</exception>
    public void RegisterNewOffer(Service service, decimal price, int durationHours, bool isActive)
    {
        if (service == null) throw new ArgumentNullException(nameof(service));

        var serviceOffer = new ServiceOffer(this.AutoRepairId, service, price, durationHours, isActive);
        ServiceOffers.Add(serviceOffer);
    }
    
    /// <summary>
    ///     Deletes a service offer associated with the specified service.
    /// </summary>
    /// <param name="service">The service whose offer should be removed.</param>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the service offer for the specified service does not exist.
    /// </exception>
    public void DeleteOffer(Service service)
    {
        var offer = ServiceOffers.FirstOrDefault(so => so.ServiceId == service.Id);
        if (offer == null)
            throw new InvalidOperationException("Service offer not found");

        ServiceOffers.Remove(offer);
    }
}
