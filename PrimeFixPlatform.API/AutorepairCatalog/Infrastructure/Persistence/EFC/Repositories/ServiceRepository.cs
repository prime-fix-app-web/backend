using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Service entities
/// </summary>
/// <param name="context">
///     The database context used for data access
/// </param>
public class ServiceRepository(AppDbContext context) : BaseRepository<Service>(context), IServiceRepository
{
    
}