using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents a service for handling role-related commands.
/// </summary>
public interface IRoleCommandService
{
    /// <summary>
    ///     Handle the seeding of roles in the system.
    /// </summary>
    /// <param name="command">
    ///     The command containing information for seeding roles.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation.
    /// </returns>
    Task Handle(SeedRolesCommand command);
}