using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Configuration;

public static class ModelBuilderExtensions
{
    public static void ApplyCollectionDiagnosis(this ModelBuilder modelBuilder)
    {
        // Data Collection Context
        // Visit Entity Configuration
        modelBuilder.Entity<Visit>().HasKey(v => v.Id);
        modelBuilder.Entity<Visit>().Property(v => v.Failure).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Visit>().Property(v => v.VehicleId).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Visit>().Property(v => v.TimeVisit).IsRequired();
        modelBuilder.Entity<Visit>().Property(v => v.AutoRepairId).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Visit>().Property(v => v.VehicleId).IsRequired().HasMaxLength(50);

        //Diagnostic Entity configuration
        modelBuilder.Entity<Diagnostic>().HasKey(d => d.Id);
        modelBuilder.Entity<Diagnostic>().Property(d => d.Price).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Diagnostic>().Property(d => d.VehicleId).HasMaxLength(50).IsRequired();
        modelBuilder.Entity < Diagnostic>().Property(d => d.Diagnosis).HasMaxLength(500).IsRequired();
        modelBuilder.Entity<Diagnostic>().Property(d => d.ExpectedVisit).IsRequired();
    }
}