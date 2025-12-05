using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Entities;

/// <summary>
///     Role aggregate root entity
/// </summary>
public partial class Role : IRole
{
    /// <summary>
    ///     Constructor for ORM tools
    /// </summary>
    protected Role() {}
    
    /// <summary>
    ///     The constructor for the Role aggregate root entity.
    /// </summary>
    /// <param name="name">
    ///     The information associated with the role.
    /// </param>
    public Role(ERole name)
    {
        Name = name;
    }
    
    public string GetStringName() => Name.ToString();
    
    /// <summary>
    ///     Converts a string name to a Role instance
    /// </summary>
    /// <param name="name">
    ///     The string name of the role.
    /// </param>
    /// <returns>
    ///     The Role instance corresponding to the provided name.
    /// </returns>
    public static Role FromName(string name)
    {
        return new Role(Enum.Parse<ERole>(name));
    }
    
    
    public int Id { get; }
    public ERole Name { get; private set; }
}