using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     Role aggregate root entity
/// </summary>
public partial class Role
{
    /// <summary>
    ///     The constructor for the Role aggregate root entity.
    /// </summary>
    /// <param name="idRole">
    ///     The unique identifier for the role.
    /// </param>
    /// <param name="roleInformation">
    ///     The information associated with the role.
    /// </param>
    public Role(string idRole, RoleInformation roleInformation)
    {
        IdRole = idRole;
        RoleInformation = roleInformation;
    }
    
    /// <summary>
    ///     The constructor for the Role aggregate root entity from CreateRoleCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a Role
    /// </param>
    public Role(CreateRoleCommand command) : this(
        command.IdRole,
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
    
    public string IdRole { get; private set; }
    public RoleInformation RoleInformation { get; private set; }
}