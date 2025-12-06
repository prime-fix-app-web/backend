using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;

public class VisitAssembler
{
    public static CreateVisitCommand ToCommandFromRequest(CreateVisitRequest request)
    {
        return new CreateVisitCommand(request.Failure, request.VehicleId, request.TimeVisit, request.AutoRepairId,
            request.ServiceId);
    }


    public static VisitResponse ToResponseFromEntity(Visit entity)
    {
        return new VisitResponse(entity.Id, entity.Failure, entity.VehicleId.Id, entity.TimeVisit, entity.AutoRepairId.Id, entity.ServiceId.Id);
    }
}