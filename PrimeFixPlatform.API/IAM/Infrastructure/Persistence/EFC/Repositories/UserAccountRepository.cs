using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

public class UserAccountRepository(AppDbContext context)
: BaseRepository<UserAccount>(context), IUserAccountRepository
{
    public async Task<bool> ExistsByIdUserAccount(string idUserAccount)
    {
        return await Context.Set<UserAccount>().AnyAsync(userAccount => userAccount.IdUserAccount == idUserAccount);
    }

    public async Task<bool> ExistsByUsername(string username)
    {
        return await Context.Set<UserAccount>().AnyAsync(userAccount => userAccount.Username == username);
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        return await Context.Set<UserAccount>().AnyAsync(userAccount => userAccount.Email == email);
    }

    public async Task<bool> ExistsByUsernameAndIdUserAccountIsNot(string username, string idUserAccount)
    {
        return await Context.Set<UserAccount>().AnyAsync(userAccount => userAccount.Username == username && userAccount.IdUserAccount != idUserAccount);
    }

    public async Task<bool> ExistsByEmailAndIdUserAccountIsNot(string email, string idUserAccount)
    {
        return await Context.Set<UserAccount>().AnyAsync(userAccount => userAccount.Email == email && userAccount.IdUserAccount != idUserAccount);
    }

    public async Task<UserAccount?> FindByUsername(string username)
    {
        return await Context.Set<UserAccount>().FirstOrDefaultAsync(userAccount => userAccount.Username == username);
    }
}