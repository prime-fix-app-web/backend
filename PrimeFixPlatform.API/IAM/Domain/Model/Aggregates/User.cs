using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

/// <summary>
///     User aggregate root entity
/// </summary>
public partial class User
{
    /// <summary>
    ///     The constructor for the User aggregate root entity.
    /// </summary>
    /// <param name="idUser">
    ///     The unique identifier for the user.
    /// </param>
    /// <param name="name">
    ///     The first name of the user.
    /// </param>
    /// <param name="lastName">
    ///     The last name of the user.
    /// </param>
    /// <param name="dni">
    ///     The national identification number of the user.
    /// </param>
    /// <param name="phoneNumber">
    ///     The phone number of the user.
    /// </param>
    /// <param name="idLocation">
    ///     The identifier for the user's location.
    /// </param>
    public User(string idUser, string name, string lastName, string dni, string phoneNumber, string idLocation)
    {
        IdUser = idUser;
        Name = name;
        LastName = lastName;
        Dni = dni;
        PhoneNumber = phoneNumber;
        IdLocation = idLocation;
    }

    /// <summary>
    ///     Constructor for User aggregate root entity from CreateUserCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a User
    /// </param>
    public User(CreateUserCommand command) : this(
        command.IdUser,
        command.Name,
        command.LastName,
        command.Dni,
        command.PhoneNumber,
        command.IdLocation)
    {
    }

    /// <summary>
    ///     Updates the user entity with data from an UpdateUserCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to update the User
    /// </param>
    public void UpdateUser(UpdateUserCommand command)
    {
        Name = command.Name;
        LastName = command.LastName;
        Dni = command.Dni;
        PhoneNumber = command.PhoneNumber;
        IdLocation = command.IdLocation;
    }
    
    public string IdUser { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Dni { get; private set; }
    public string PhoneNumber { get; private set; }
    public string IdLocation { get; private set; }
}