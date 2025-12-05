using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL.Services;

public class CollectionDiagnosisContextFacade(
    IDiagnosticCommandService diagnosticCommandService,
    IDiagnosticQueryService diagnosticQueryService,
    IVisitQueryService visitQueryService) : ICollectionDiagnosisContextFacade
{
    public async Task<int> CreateDiagnostic(float price, int vehicleId, string diagnosis, int expectedVisitId)
    {
        var createDiagnosticCommand = new CreateDiagnosisCommand(price, vehicleId, diagnosis, expectedVisitId);
        var diagnostic = await diagnosticCommandService.Handle(createDiagnosticCommand);
        return diagnostic?.Id ?? 0;
    }
    
    public async Task<int> FetchDiagnosticById(int diagnosticId)
    {
        var getDiagnosticById = new GetDiagnosticByIdQuery(diagnosticId);
        var diagnostic = await diagnosticQueryService.Handle(getDiagnosticById);
        return  diagnostic?.Id ?? 0;
    }
    
    public async Task<int> FetchDiagnosticByVehicleId(int vehicleId)
    {
        var getDiagnosticByVehicleId = new GetDiagnosticsByVehicleIdQuery(vehicleId);
        var diagnostic = await diagnosticQueryService.Handle(getDiagnosticByVehicleId);
        return diagnostic?.Id ?? 0;
    }
    
    public async Task<int> FetchDiagnosticByExpectedVisitId(int expectedVisitId)
    {
        var getDiagnosticByExpectedVisitId = new GetDiagnosticsByExpectedVisitQuery(expectedVisitId);
        var diagnostic = await diagnosticQueryService.Handle(getDiagnosticByExpectedVisitId);
        return diagnostic?.Id ?? 0;
    }
    
    public async Task<int> FetchVisitById(int visitId)
    {
        var getVisitById = new GetVisitByIdQuery(visitId);
        var visit = await visitQueryService.Handle(getVisitById);
        return visit?.Id??0;
    }

    public async Task<int> FetchVisitByVehicleId(int vehicleId)
    {
        var getVisitByVehicleId = new GetVisitByVehicleIdQuery(vehicleId);
        var visit = await visitQueryService.Handle(getVisitByVehicleId);
        return visit?.Id ?? 0;
    }

    public async Task<int> FetchVisitByAutoRepairId(int autoRepairId)
    {
        var getVisitByAutoRepairId = new GetVisitsByAutoRepairIdQuery(autoRepairId);
        var visit = await visitQueryService.Handle(getVisitByAutoRepairId);
        return visit?.Id ?? 0;
    }

    public async Task<int> FetchVisitByServiceId(int serviceId)
    {
        var getVisitByServiceId = new GetVisitByServiceIdQuery(serviceId);
        var visit = await visitQueryService.Handle(getVisitByServiceId);
        return visit?.Id ?? 0;
    }
}