using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;

/// <summary>
/// Diagnostic aggregate root entity
/// </summary>
public partial class Diagnostic
{
    /// <summary>
    ///      The constructor for the Diagnostic aggregate root entity. 
    /// </summary>
    /// <param name="price">
    ///     The estimated price of the Diagnosis
    /// </param>
    /// <param name="vehicleId">
    ///     The vehicle Id of the Diagnosis
    /// </param>
    /// <param name="diagnosis">
    ///     The description of the Diagnosis
    /// </param>
    /// <param name="expectedId">
    ///     The expected Visit id of the Diagnosis
    /// </param>
    public Diagnostic(float price, string vehicleId, string diagnosis, string expectedId)
    {
        Price = price;
        VehicleId = vehicleId;
        Diagnosis = diagnosis;
        ExpectedId = expectedId;
    }

    /// <summary>
    ///     Constructor for diagnostic entity with data from CreateDiagnosisCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a diagnstic.
    /// </param>
    public Diagnostic(CreateDiagnosisCommand command) : this(command.Price, command.VehicleId, command.Diagnosis, command.ExpectedId){}

    /// <summary>
    ///     Updates the diagnostic entity with data form UpdateDiagnosticCommand
    /// </summary>
    /// <param name="command">
    ///     Command object containing data to create a diagnstic.
    /// </param>
    public void UpdateDiagnosis(UpdateDiagnosisCommand command)
    {
        Price = command.Price;
        VehicleId = command.VehicleId;
        Diagnosis = command.Diagnosis;
        ExpectedId = command.ExpectedId;
    }
    
    public string Id { get; }
    public float Price { get; private set; }
    public string VehicleId { get; private set; }
    public string Diagnosis { get; private set; }
    public string ExpectedId { get; private set; }
    
    public ExpectedVisit ExpectedVisit { get; internal set; }
}