using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Extensions for ModelBuilder to configure the Autorepair Catalog Bounded Context
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Configures the Autorepair Catalog Bounded Context entities
    /// </summary>
    /// <param name="modelBuilder">
    ///     The ModelBuilder instance to configure
    /// </param>
    public static void ApplyAutorepairCatalogConfiguration(this ModelBuilder modelBuilder)
    {
        // Autorepair Catalog Bounded Context
        modelBuilder.Entity<AutoRepair>().HasKey(ar => ar.IdAutoRepair);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.IdAutoRepair).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.Ruc).IsRequired().HasMaxLength(11);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.ContactEmail).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.TechniciansCount).IsRequired();
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.IdUserAccount).IsRequired().HasMaxLength(255);

        modelBuilder.Entity<Location>().HasKey(l => l.IdLocation);
        modelBuilder.Entity<Location>().Property(l => l.IdLocation).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Location>().Property(l => l.Address).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Location>().Property(l => l.District).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Location>().Property(l => l.Department).IsRequired().HasMaxLength(50);
    }
}