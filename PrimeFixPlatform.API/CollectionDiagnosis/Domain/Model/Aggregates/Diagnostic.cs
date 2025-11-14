using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;

/// <summary>
/// Diagnostic aggregate root entity
/// </summary>
public partial class Diagnostic
{
    public Diagnostic(float price, string vehicleId, string diagnosis, string expectedId)
    {
        Price = price;
        VehicleId = vehicleId;
        Diagnosis = diagnosis;
        ExpectedId = expectedId;
    }
    
    
    public float Price { get; private set; }
    public string VehicleId { get; private set; }
    public string Diagnosis { get; private set; }
    public string ExpectedId { get; private set; }
    
    public ExpectedVisit ExpectedVisit { get; internal set; }
}