namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

/// <summary>
///     Service aggregate root entity
/// </summary>
public partial class Service
{
    public Service(string name , string description)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
}