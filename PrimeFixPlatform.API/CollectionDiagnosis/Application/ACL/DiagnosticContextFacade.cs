using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.ACL;

public class DiagnosticContextFacade(
    IDiagnosticCommandService diagnosticCommandService,
    IDiagnosticQueryService diagnosticQueryService) : IDiagnosticContextFacade
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
}