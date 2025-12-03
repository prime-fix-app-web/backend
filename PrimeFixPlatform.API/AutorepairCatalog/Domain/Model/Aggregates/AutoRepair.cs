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
    /// <param name="idAutoRepair">
    ///     The unique identifier of the auto repair
    /// </param>
    /// <param name="ruc">
    ///     The Single Taxpayer Registry number of the auto repair
    /// </param>
    /// <param name="contactEmail">
    ///     The contact email of the auto repair
    /// </param>
    /// <param name="techniciansCount">
    ///     The number of technicians in the auto repair
    /// </param>
    /// <param name="idUserAccount">
    ///     The unique identifier of the user account associated with the auto repair
    /// </param>
    public AutoRepair(int idAutoRepair, string ruc, string contactEmail, int techniciansCount, int idUserAccount)
    {
        IdAutoRepair = idAutoRepair;
        Ruc = ruc;
        ContactEmail = contactEmail;
        TechniciansCount = techniciansCount;
        IdUserAccount = idUserAccount;
    }
    
    /// <summary>
    ///     Constructor from CreateAutoRepairCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the auto repair
    /// </param>
    public AutoRepair(CreateAutoRepairCommand command): this(
        command.IdAutoRepair,
        command.Ruc,
        command.ContactEmail,
        command.TechniciansCount,
        command.IdUserAccount)
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
        TechniciansCount = command.TechniciansCount;
        IdUserAccount = command.IdUserAccount;
    }
    
    public int IdAutoRepair { get; private set;  }
    public string Ruc { get; private set;  }
    public string ContactEmail { get; private set;  }
    public int TechniciansCount { get; private set;  }
    public int IdUserAccount { get; private set;  }
    public ServiceCatalog ServiceCatalog { get; private set; }

    public void RegisterNewOffer(Service service, decimal price)
    {
        ServiceCatalog.AddServiceOffer(this, service, price);
    }
}