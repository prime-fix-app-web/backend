using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     UserAccount Aggregate Root
/// </summary>
public partial class UserAccount
{
    /// <summary>
    ///     Constructor for UserAccount Aggregate Root
    /// </summary>
    /// <param name="idUserAccount">
    ///     The unique identifier for the UserAccount
    /// </param>
    /// <param name="username">
    ///     The username of the UserAccount
    /// </param>
    /// <param name="email">
    ///     The email of the UserAccount
    /// </param>
    /// <param name="idRole">
    ///     The role identifier associated with the UserAccount
    /// </param>
    /// <param name="idUser">
    ///     The user identifier associated with the UserAccount
    /// </param>
    /// <param name="password">
    ///     The password of the UserAccount
    /// </param>
    /// <param name="isNew">
    ///     Flag indicating if the UserAccount is new
    /// </param>
    public UserAccount(string idUserAccount, string username, string email, string idRole, string idUser, string password, bool isNew)
    {
        IdUserAccount = idUserAccount;
        Username = username;
        Email = email;
        IdRole = idRole;
        IdUser = idUser;
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
        command.IdUserAccount,
        command.Username,
        command.Email,
        command.IdRole,
        command.IdUser,
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
        IdRole = command.IdRole;
        IdUser = command.IdUser;
        Password = command.Password;
        IsNew = command.IsNew;
    }
    
    
    public string IdUserAccount { get; private set; }

    public string Username { get; private set; }
    
    public string Email { get; private set; }
    
    public string IdRole { get; private set; }
    
    public string IdUser { get; private set; }
    
    public string Password { get; private set; }
    
    public bool IsNew { get; private set; }
}