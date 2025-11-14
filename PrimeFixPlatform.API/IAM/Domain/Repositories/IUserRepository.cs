using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.Iam.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing User entities.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> ExistsByIdUser(string idUser);
    
    Task<bool> ExistsByNameAndLastName(string name, string lastName);
    
    Task<bool> ExistsByNameAndLastNameAndIdUserIsNot(string name, string lastName, string idUser);
}