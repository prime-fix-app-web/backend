using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;

public record UpdateStatusExpectedVisitCommand(Status NewStatus, int ExpectedVisitId);