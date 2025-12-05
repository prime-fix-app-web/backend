using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Role entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class RoleRepository(AppDbContext context)
: BaseRepository<Role>(context), IRoleRepository
{
    public async Task<Role?> GetByNameAsync(ERole name)
    {
        return await Context.Set<Role>().FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task<bool> ExistsByNameAsync(ERole name)
    {
        return await Context.Set<Role>().AnyAsync(r => r.Name == name);
    }
}