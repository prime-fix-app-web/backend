using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Aggregates;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Configuration;

public static class ModelBuilderExtensions
{
    public static void ApplyCollectionDiagnosis(this ModelBuilder modelBuilder)
    {
        // ================= Visit =================
        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(v => v.Id);
            entity.Property(v => v.Id).ValueGeneratedOnAdd();
            entity.Property(v => v.Failure).HasMaxLength(100).IsRequired();
            entity.Property(v => v.TimeVisit).IsRequired();

            // ValueObjects como ValueConversion
            entity.Property(v => v.VehicleId)
                  .HasConversion(
                      v => v.Id,
                      v => new VehicleId(v)
                  )
                  .HasColumnName("VehicleId")
                  .IsRequired();

            entity.Property(v => v.ServiceId)
                  .HasConversion(
                      v => v.Id,
                      v => new ServiceId(v)
                  )
                  .HasColumnName("ServiceId")
                  .IsRequired();

            entity.Property(v => v.AutoRepairId)
                  .HasConversion(
                      v => v.Id,
                      v => new AutoRepairId(v)
                  )
                  .HasColumnName("AutoRepairId")
                  .IsRequired();
        });

        // ================= ExpectedVisit =================
        modelBuilder.Entity<ExpectedVisit>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StateVisit)
                  .HasConversion<string>() // enum o string
                  .IsRequired();

            entity.Property(e => e.IsScheduled).IsRequired();

            entity.HasOne<Visit>()
                  .WithMany()
                  .HasForeignKey(e => e.VisitId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ================= Diagnostic =================
        modelBuilder.Entity<Diagnostic>(entity =>
        {
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Id).ValueGeneratedOnAdd();

            entity.Property(d => d.Price).IsRequired();
            entity.Property(d => d.Diagnosis).HasMaxLength(500).IsRequired();
            entity.Property(d => d.ExpectedVisitId).IsRequired();

            // VehicleId como ValueConversion
            entity.Property(d => d.VehicleId)
                  .HasConversion(
                      v => v.Id,
                      v => new VehicleId(v)
                  )
                  .HasColumnName("VehicleId")
                  .IsRequired();

            entity.HasOne<ExpectedVisit>()
                  .WithMany()
                  .HasForeignKey(d => d.ExpectedVisitId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
