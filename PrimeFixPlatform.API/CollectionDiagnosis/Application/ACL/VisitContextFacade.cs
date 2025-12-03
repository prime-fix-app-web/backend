using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.ACL;

public class VisitContextFacade(
    IVisitCommandService visitCommandService,
    IVisitQueryService visitQueryService
    ):IVisitContextFacade
{
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