using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context)
: BaseRepository<User>(context),  IUserRepository
{
    public async Task<bool> ExistsByIdUser(string idUser)
    {
        return await Context.Set<User>().AnyAsync(user => user.IdUser == idUser);
    }

    public async Task<bool> ExistsByNameAndLastName(string name, string lastName)
    {
        return await Context.Set<User>().AnyAsync(user => user.Name == name && user.LastName == lastName);
    }

    public async Task<bool> ExistsByNameAndLastNameAndIdUserIsNot(string name, string lastName, string idUser)
    {
        return await Context.Set<User>().AnyAsync(user => user.Name == name && user.LastName == lastName && user.IdUser != idUser);
    }
}