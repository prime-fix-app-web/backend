using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PrimeFixPlatform.API.AutorepairRegister.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PrimeFixPlatform.API.MaintenanceTracking.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PrimeFixPlatform.API.PaymentService.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Create all entities configurations
        builder.ApplyIamConfiguration();
        builder.ApplyAutorepairRegisterConfiguration();
        builder.ApplyAutorepairCatalogConfiguration();
        builder.ApplyMaintenanceTrackingConfiguration();
        builder.ApplyPaymentServiceConfiguration();
        builder.ApplyCollectionDiagnosis();

        builder.UseSnakeCaseNamingConvention();
    }
}