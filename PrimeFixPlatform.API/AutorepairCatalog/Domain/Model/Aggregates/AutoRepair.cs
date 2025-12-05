using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;

/// <summary>
///     AutoRepair Aggregate Root
/// </summary>
public partial class AutoRepair 
{
    /// <summary>
    ///     Private constructor for ORM
    /// </summary>
    private AutoRepair() { }
    
    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    /// <param name="ruc">
    ///     The Single Taxpayer Registry number of the auto repair
    /// </param>
    /// <param name="contactEmail">
    ///     The contact email of the auto repair
    /// </param>
    /// <param name="userAccountId">
    ///     The unique identifier of the user account associated with the auto repair
    /// </param>
    public AutoRepair( string ruc, string contactEmail, int userAccountId)
    {
        Ruc = ruc;
        ContactEmail = contactEmail;
        TechniciansCount = 0;
        UserAccountId = userAccountId;
    }
    
    /// <summary>
    ///     Constructor from CreateAutoRepairCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the auto repair
    /// </param>
    public AutoRepair(CreateAutoRepairCommand command): this(
        command.Ruc,
        command.ContactEmail,
        command.UserAccountId)
    {
    }
    
    /// <summary>
    ///     Updates the AutoRepair entity with data from the UpdateAutoRepairCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to update the auto repair
    /// </param>
    public void UpdateAutoRepair(UpdateAutoRepairCommand command)
    {
        Ruc = command.Ruc;
        ContactEmail = command.ContactEmail;
        UserAccountId = command.UserAccountId;
    }
    
    /// <summary>
    ///     Increments the count of technicians associated with the auto repair
    /// </summary>
    public void IncrementTechniciansCount()
    {
        TechniciansCount++;
    }
    
    /// <summary>
    ///     Decrements the count of technicians associated with the auto repair
    /// </summary>
    public void DecrementTechniciansCount()
    {
        if (TechniciansCount > 0)
        {
            TechniciansCount--;
        }
    }
    
    public int Id { get; }
    public string Ruc { get; private set;  }
    public string ContactEmail { get; private set;  }
    public int TechniciansCount { get; private set;  }
    public int UserAccountId { get; private set;  }
    public ServiceCatalog ServiceCatalog { get; private set; }

    public void RegisterNewOffer(Service service, decimal price, int durationHours, bool isActive)
    {
        ServiceCatalog.AddServiceOffer(this, service, price, isActive, durationHours);
    }

    public void DeleteOffer(Service service)
    {
        ServiceCatalog.RemoveServiceOffer(this, service);
    }
}