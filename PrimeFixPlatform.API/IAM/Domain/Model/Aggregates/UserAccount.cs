using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     UserAccount Aggregate Root
/// </summary>
public partial class UserAccount
{
    /// <summary>
    ///     Constructor for UserAccount Aggregate Root
    /// </summary>
    /// <param name="username">
    ///     The username of the UserAccount
    /// </param>
    /// <param name="email">
    ///     The email of the UserAccount
    /// </param>
    /// <param name="roleId">
    ///     The role identifier associated with the UserAccount
    /// </param>
    /// <param name="userId">
    ///     The user identifier associated with the UserAccount
    /// </param>
    /// <param name="membershipId">
    ///     The membership identifier associated with the UserAccount
    /// </param>
    /// <param name="password">
    ///     The password of the UserAccount
    /// </param>
    /// <param name="isNew">
    ///     Flag indicating if the UserAccount is new
    /// </param>
    public UserAccount(string username, string email, int roleId, int userId, int membershipId ,string password, bool isNew)
    {
        Username = username;
        Email = email;
        RoleId = roleId;
        UserId = userId;
        MembershipId = membershipId;
        Password = password;
        IsNew = isNew;
    }
    
    /// <summary>
    ///     Constructor for UserAccount Aggregate Root from CreateUserAccountCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a UserAccount
    /// </param>
    public UserAccount(CreateUserAccountCommand command): this(
        command.Username,
        command.Email,
        command.RoleId,
        command.UserId,
        command.MembershipId,
        command.Password,
        command.IsNew)
    {
    }
    
    /// <summary>
    ///     Constructor for UserAccount Aggregate Root from UpdateUserAccountCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to update a UserAccount
    /// </param>
    public void UpdateUserAccount(UpdateUserAccountCommand command)
    {
        Username = command.Username;
        Email = command.Email;
        RoleId = command.RoleId;
        UserId = command.UserId;
        MembershipId = command.MembershipId;
        Password = command.Password;
        IsNew = command.IsNew;
    }
    
    
    public int Id { get; }

    public string Username { get; private set; }
    
    public string Email { get; private set; }
    
    public int RoleId { get; private set;  }
    
    public Role Role { get; internal set; }
    
    public int UserId { get; private set;  }
    
    public User User { get; internal set; }
    public int MembershipId { get; private set; }
    
    public Membership Membership { get; internal set; }
    
    public string Password { get; private set; }
    
    public bool IsNew { get; private set; }
}