using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;

public class ServiceOffer
{
    /// <summary>
    ///     Private constructor for ORM
    /// </summary>
    private ServiceOffer() { }

    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    public ServiceOffer(int idAutoRepair, int idService, decimal price)
    {
        IdAutoRepair = idAutoRepair;
        IdService = idService;
        Price = price;
    }

    /// <summary>
    ///     Updates the price of the service offer
    /// </summary>
    public void UpdatePrice(decimal price)
    {
        Price = price;
    }
    

    public int Id { get; private set; }

    public int IdAutoRepair { get; private set; }
    public AutoRepair AutoRepair { get; private set; } = null!;

    public int IdService { get; private set; }
    public Service Service { get; private set; } = null!;
    public decimal Price { get; private set; }
}