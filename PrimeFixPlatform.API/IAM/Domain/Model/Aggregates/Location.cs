using PrimeFixPlatform.API.IAM.Domain.Model.Commands;

namespace PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;

/// <summary>
///     Location Aggregate Root
/// </summary>
public partial class Location
{
    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    /// <param name="address">
    ///     The address of the location
    /// </param>
    /// <param name="district">
    ///     The district of the location
    /// </param>
    /// <param name="department">
    ///     The department of the location
    /// </param>
    public Location( string address, string district, string department)
    {
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
    
    public int Id { get; }
    public string Address { get; private set; }
    public string District { get; private set; }
    public string Department { get; private set; }
}