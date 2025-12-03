using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL;

public interface IDiagnosticContextFacade
{
    
    Task<int> CreateDiagnostic(
        float price,
        int vehicleId,
        string diagnosis,
        int expectedVisitId);
    
    
    Task<int> FetchDiagnosticById(int diagnosticId);
    
    
    Task<int> FetchDiagnosticByVehicleId(int vehicleId);
    
    Task<int> FetchDiagnosticByExpectedVisitId(int expectedVisitId );
}