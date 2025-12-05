using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Services;

namespace PrimeFixPlatform.API.IAM.Application.Internal.EventHandlers;

/// <summary>
///     Service that runs on application startup to seed roles
/// </summary>
/// <param name="logger">
///     The logger instance
/// </param>
/// <param name="roleCommandService">
///     The service responsible for handling role commands
/// </param>
public class ApplicationStartupService(ILogger<ApplicationStartupService> logger,
    IRoleCommandService roleCommandService) 
    : IHostedService
{
    /// <summary>
    ///     Start the service to seed roles on application startup
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting roles seeding verification at {Time}", DateTime.UtcNow);

        var seedRolesCommand = new SeedRolesCommand();
        await roleCommandService.Handle(seedRolesCommand);

        logger.LogInformation("ERole seeding verification finished at {Time}", DateTime.UtcNow);
    }

    /// <summary>
    ///     Stop the service
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}