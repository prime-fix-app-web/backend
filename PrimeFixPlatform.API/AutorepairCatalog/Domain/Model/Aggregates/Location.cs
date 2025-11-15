using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;

/// <summary>
///     Location Aggregate Root
/// </summary>
public partial class Location
{
    /// <summary>
    ///     Private constructor for ORM
    /// </summary>
    private Location() { }
    
    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    /// <param name="idLocation">
    ///     The unique identifier of the location
    /// </param>
    /// <param name="address">
    ///     The address of the location
    /// </param>
    /// <param name="district">
    ///     The district of the location
    /// </param>
    /// <param name="department">
    ///     The department of the location
    /// </param>
    public Location(string idLocation, string address, string district, string department)
    {
        IdLocation = idLocation;
        Address = address;
        District = district;
        Department = department;
    }
    
    /// <summary>
    ///     Constructor from CreateLocationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the location
    /// </param>
    public Location(CreateLocationCommand command): this(
        command.IdLocation,
        command.Address,
        command.District,
        command.Department)
    {
    }

    /// <summary>
    ///     Updates the Location entity with data from the UpdateLocationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to update the location
    /// </param>
    public void UpdateLocation(UpdateLocationCommand command)
    {
        Address = command.Address;
        District = command.District;
        Department = command.Department;
    }
    
    public string IdLocation { get; private set; }
    public string Address { get; private set; }
    public string District { get; private set; }
    public string Department { get; private set; }
}