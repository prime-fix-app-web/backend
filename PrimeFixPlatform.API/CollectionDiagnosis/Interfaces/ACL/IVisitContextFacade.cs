namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL;

public interface IVisitContextFacade
{
    Task<int> FetchVisitById(int visitId);
    
    Task<int> FetchVisitByVehicleId(int vehicleId);
    
    Task<int> FetchVisitByAutoRepairId(int autoRepairId);
    
    Task<int> FetchVisitByServiceId(int serviceId);
}