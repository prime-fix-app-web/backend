using PrimeFixPlatform.API.IAM.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;

/// <summary>
///     Location Aggregate Root
/// </summary>
public partial class Location
{
    /// <summary>
    ///     Constructor for ORM
    /// </summary>
    protected Location() { }
    /// <summary>
    ///     Constructor with all parameters
    /// </summary>
    /// <param name="locationInformation">
    ///     The location information value object containing address, district, and department.
    /// </param>
    public Location( LocationInformation locationInformation)
    {
        LocationInformation = locationInformation;
    }
    
    /// <summary>
    ///     Constructor from CreateLocationCommand
    /// </summary>
    /// <param name="command">
    ///     The command containing the data to create the location
    /// </param>
    public Location(CreateLocationCommand command): this(
        command.LocationInformation)
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
        LocationInformation = command.LocationInformation;
    }
    
    public int Id { get; }
    public LocationInformation LocationInformation { get; private set; }
}