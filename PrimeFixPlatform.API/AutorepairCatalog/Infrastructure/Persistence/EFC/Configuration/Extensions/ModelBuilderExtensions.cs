using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Entities;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.ValueObjects;

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
        modelBuilder.Entity<AutoRepair>().HasKey(ar => ar.Id);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.Id).IsRequired();
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.Ruc).IsRequired().HasMaxLength(11);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.ContactEmail).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.TechniciansCount).IsRequired();
        modelBuilder.Entity<AutoRepair>().Property(ar => ar.UserAccountId).IsRequired();
        modelBuilder.Entity<AutoRepair>().Ignore(ar => ar.ServiceCatalog);
        modelBuilder.Entity<AutoRepair>()
            .HasMany(ar => ar.ServiceOffers)
            .WithOne(so => so.AutoRepair)
            .HasForeignKey(so => so.AutoRepairId)
            .IsRequired();

        modelBuilder.Entity<ServiceOffer>(so =>
        {
            so.HasKey(x => x.ServiceOfferId);
            so.Property(x => x.Price).IsRequired();
            so.Property(x => x.DurationHours).IsRequired();
            so.Property(x => x.IsActive).IsRequired();

            so.HasOne(x => x.AutoRepair)
                .WithMany(ar => ar.ServiceOffers)
                .HasForeignKey(x => x.AutoRepairId);

            so.HasOne(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceId);
        });

        modelBuilder.Entity<Location>().HasKey(l => l.Id);
        modelBuilder.Entity<Location>().Property(l => l.Address).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Location>().Property(l => l.District).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Location>().Property(l => l.Department).IsRequired().HasMaxLength(50);

        modelBuilder.Entity<Service>().HasKey(s => s.Id);
        modelBuilder.Entity<Service>().Property(s => s.Name).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Service>().Property(s => s.Description).IsRequired().HasMaxLength(255);
    }
}