using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Queries;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/diagnostics")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Diagnostic Endpoints")]
public class DiagnosticController(IDiagnosticQueryService diagnosticQueryService, IDiagnosticCommandService diagnosticCommandService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Diagnostic Resource",
        Description = "Creates a new Diagnostic Resource",
        OperationId = "DiagnosticCreate")]
    [SwaggerResponse(StatusCodes.Status200OK, "Creates a new Diagnostic Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Creates a new Diagnostic Resource")]
    public async Task<IActionResult> CreateDiagnostic([FromBody] CreateDiagnosticRequest request)
    {
        var createDiagnosticCommand = DiagnosticAssembler.ToCommandFromRequest(request);
        var diagnostic = await diagnosticCommandService.Handle(createDiagnosticCommand);
        if (diagnostic == null) return BadRequest();
        var diagnosticResource = DiagnosticAssembler.ToResponseFromEntity(diagnostic);
        return Ok(diagnosticResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a list of Diagnostic Resource",
        Description = "Gets a list of Diagnostic Resource",
        OperationId = "DiagnosticGet"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "Gets a list of Diagnostic Resource")]
    public async Task<IActionResult> GetAllDiagnostic()
    {
        var diagnostics = await diagnosticQueryService.Handle(new GetAllDiagnosticsQuery());
        var diagnosticResource = diagnostics.Select(DiagnosticAssembler.ToResponseFromEntity);
        return Ok(diagnosticResource);
    }
    
    [HttpDelete]
    [SwaggerOperation(
        Summary = "Deletes a Diagnostic Resource",
        Description = "Deletes a Diagnostic Resource",
        OperationId = "DiagnosticDelete"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletes a Diagnostic Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Deletes a Diagnostic Resource")]
    public async Task<IActionResult> DeleteDiagnostic(int diagnosticId)
    {
        var deleteDiagnostic = new DeleteDiagnosisCommand(diagnosticId);
        var result = await diagnosticCommandService.Handle(deleteDiagnostic);

        if (result == null) return BadRequest();
        
        return Ok(result);
    }
    
    [HttpPut("{diagnosticId}")]
    [SwaggerOperation(
        Summary = "Updates a Diagnostic Resource",
        Description = "Updates a Diagnostic Resource",
        OperationId = "DiagnosticUpdate"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "Updates a Diagnostic Resource")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Updates a Diagnostic Resource")]
    public async Task<IActionResult> UpdateDiagnostic([FromBody] UpdateDiagnosticRequest request, int diagnosticId)
    {
        var updateDiagnostic = DiagnosticAssembler.ToCommandFromRequest(request, diagnosticId);
        var diagnosis = await diagnosticCommandService.Handle(updateDiagnostic);
        if (diagnosis is null) return BadRequest();
        
        var diagnosisResponse = DiagnosticAssembler.ToResponseFromEntity(diagnosis);
        return Ok(diagnosisResponse);

    }
}