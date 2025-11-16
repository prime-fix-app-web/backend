using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;

public class DiagnosticAssembler
{
    public static CreateDiagnosisCommand ToCommandFromRequest(CreateDiagnosticRequest request)
    {
        return new CreateDiagnosisCommand(request.Price, request.VehicleId, request.Diagnosis, request.ExpectedVisitId);
    }


    public static UpdateDiagnosisCommand ToCommandFromRequest(UpdateDiagnosticRequest request)
    {
        return new UpdateDiagnosisCommand(request.DiagnosisId, request.Price, request.VehicleId, request.Diagnosis, request.ExpectedVisitId);
    }


    public static DiagnosticResponse ToResponseFromEntity(Diagnostic entity)
    {
        return new DiagnosticResponse(entity.Id,entity.Price,entity.VehicleId, entity.Diagnosis, entity.ExpectedVisitId);
    }
}