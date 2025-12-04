using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using Service = PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates.Service;

namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;

/// <summary>
/// Represents the repository interface for managing services entities
/// </summary>
public interface IServiceRepository : IBaseRepository<Service>
{

}