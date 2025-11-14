using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;

public interface IDiagnosticRepository : IBaseRepository<Diagnostic>
{
    
}