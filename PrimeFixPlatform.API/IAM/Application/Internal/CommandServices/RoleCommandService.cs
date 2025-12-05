using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;

/// <summary>
///     Command service for Role aggregate
/// </summary>
/// <param name="roleRepository">
///     The role repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
: IRoleCommandService
{
    /// <summary>
    ///     Handle the SeedRolesCommand
    /// </summary>
    /// <param name="command">
    ///     The SeedRolesCommand
    /// </param>
    public async Task Handle(SeedRolesCommand command)
    {
        foreach (var role in Enum.GetValues<ERole>())
        {
            var exists = await roleRepository.ExistsByNameAsync(role);
            if (!exists)
            {
                await roleRepository.AddAsync(new Role(role));
            }
            await unitOfWork.CompleteAsync();
        }
    }
}