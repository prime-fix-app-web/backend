using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     Role aggregate root entity
/// </summary>
public partial class Role
{
    /// <summary>
    ///     Private constructor for ORM and serialization purposes
    /// </summary>
    private Role() { }
    /// <summary>
    ///     The constructor for the Role aggregate root entity.
    /// </summary>
    /// <param name="roleInformation">
    ///     The information associated with the role.
    /// </param>
    public Role( RoleInformation roleInformation)
    {
        RoleInformation = roleInformation;
    }
    
    /// <summary>
    ///     The constructor for the Role aggregate root entity from CreateRoleCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a Role
    /// </param>
    public Role(CreateRoleCommand command) : this(
       command.RoleInformation)
    {
    }
    
    /// <summary>
    ///     Updates the role entity with data from an UpdateRoleCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to update a Role
    /// </param>
    public void UpdateRole(UpdateRoleCommand command)
    {
        RoleInformation = command.RoleInformation;
    }
    
    public int RoleId { get; private set; }
    public RoleInformation RoleInformation { get; private set; }
}