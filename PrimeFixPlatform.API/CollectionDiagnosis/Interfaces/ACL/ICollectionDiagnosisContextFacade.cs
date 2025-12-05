using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL;

public interface ICollectionDiagnosisContextFacade
{
    
    Task<int> CreateDiagnostic(
        float price,
        int vehicleId,
        string diagnosis,
        int expectedVisitId);
    
    
    Task<int> FetchDiagnosticById(int diagnosticId);
    
    
    Task<int> FetchDiagnosticByVehicleId(int vehicleId);
    
    Task<int> FetchDiagnosticByExpectedVisitId(int expectedVisitId );

    Task<int> FetchVisitById(int visitId);

    Task<int> FetchVisitByVehicleId(int vehicleId);

    Task<int> FetchVisitByAutoRepairId(int autoRepairId);

    Task<int> FetchVisitByServiceId(int serviceId);
}