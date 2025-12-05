using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Services;

namespace PrimeFixPlatform.API.IAM.Application.Internal.EventHandlers;

public class ApplicationStartupService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationStartupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var roleCommandService = scope.ServiceProvider.GetRequiredService<IRoleCommandService>();

        await roleCommandService.Handle(new SeedRolesCommand());
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}