using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;

public static class ExpectedVisitAssembler
{
    public static CreateExpectedVisitCommand ToCommandFromRequest(CreateExpectedVisitRequest request)
    {
        return new CreateExpectedVisitCommand(
            request.VisitId, request.VehicleId
        );
    }


    public static UpdateExpectedVisitCommand ToCommandFromRequest(UpdateExpectedVisitRequest request, int expectedId)
    {
        return new UpdateExpectedVisitCommand( expectedId, StateVisitExtensions.ToStateVisit(request.StateVisit), request.VisitId, request.IsScheduled, request.VehicleId);
    }

    public static UpdateStatusExpectedVisitCommand ToCommandFromRequestStatus(UpdateStatusExpectedVisitRequest request, int expectedVisitId)
    {
        return new UpdateStatusExpectedVisitCommand(StateVisitExtensions.ToStateVisit(request.StateVisit), expectedVisitId);
    }

    public static CancelVisitCommand ToCommandFromRequest(int visitId)
    {
        return new CancelVisitCommand(visitId);
    }

    public static ExpectedVisitResponse ToResponseFromEntity(ExpectedVisit expectedVisit)
    {
        return new ExpectedVisitResponse(
            expectedVisit.Id,
            expectedVisit.StateVisit.ToString(),
            expectedVisit.VisitId,
            expectedVisit.IsScheduled,
            expectedVisit.VehicleId
        );
    }
}