using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Repositories;
/// <summary>
///     Repository for managing Diagnostic entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class DiagnosticRepository(AppDbContext context): BaseRepository<Diagnostic>(context), IDiagnosticRepository
{
    /// <summary>
    ///     Finds the Diagnostic associated with the given Vehicle ID.
    /// </summary>
    /// <param name="vehicleId">
    ///     The identifier of the vehicle used to filter Diagnostic records.
    /// </param>
    /// <returns>
    ///     The matching Diagnostic if found; otherwise, null.
    /// </returns>
    public async Task<Diagnostic?> FindByVehicleId(string vehicleId)
    {
        return await Context.Set<Diagnostic>().FirstOrDefaultAsync(diagnostic => diagnostic.VehicleId == vehicleId);
    }

}