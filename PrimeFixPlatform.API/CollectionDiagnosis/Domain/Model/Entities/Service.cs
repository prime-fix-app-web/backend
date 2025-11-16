using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

/// <summary>
///     Service aggregate root entity
/// </summary>
public partial class Service
{
    /// <summary>
    ///     The constructor for the Service aggregate root entity
    /// </summary>
    /// <param name="name">
    ///     The name of the Service
    /// </param>
    /// <param name="description">
    ///     The description of the Service
    /// </param>
    public Service(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Service(CreateServiceCommand command)
    {
        Name= command.Name;
        Description = command.Description;
    }

    public void UpdateService(UpdateServiceCommand command)
    {
        Name = command.Name;
        Description = command.Description;
    }

public string Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
}