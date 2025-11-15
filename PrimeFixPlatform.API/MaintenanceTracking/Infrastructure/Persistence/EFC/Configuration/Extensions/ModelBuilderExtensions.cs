using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.MaintenanceTracking.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Extensions for configuring the ModelBuilder for the MaintenanceTracking Bounded Context
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the MaintenanceTracking configuration to the ModelBuilder
    /// </summary>
    /// <param name="modelBuilder">
    ///     The ModelBuilder to configure
    /// </param>
    public static void ApplyMaintenanceTrackingConfiguration(this ModelBuilder modelBuilder)
    {
        // MaintenanceTracking Bounded Context
        modelBuilder.Entity<Vehicle>().HasKey(v => v.IdVehicle);
        modelBuilder.Entity<Vehicle>().Property(v => v.IdVehicle).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Vehicle>().Property(v => v.Color).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Vehicle>().Property(v => v.Model).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Vehicle>().Property(v => v.IdUser).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Vehicle>().Property(v => v.MaintenanceStatus).IsRequired();
        modelBuilder.Entity<Vehicle>().OwnsOne(v => v.VehicleInformation, vi =>
        {
            vi.WithOwner().HasForeignKey("VehicleIdVehicle");
            vi.Property<string>("VehicleIdVehicle").HasColumnName("id_vehicle");
            vi.Property(p => p.VehiclePlate).IsRequired().HasMaxLength(10);
            vi.Property(p => p.VehicleBrand).IsRequired().HasMaxLength(50);
            vi.Property(p => p.VehicleType).IsRequired().HasMaxLength(50);
        });
        
        modelBuilder.Entity<Notification>().HasKey(n => n.IdNotification);
        modelBuilder.Entity<Notification>().Property(n => n.IdNotification).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Notification>().Property(n => n.Message).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Notification>().Property(n => n.Read).IsRequired();
        modelBuilder.Entity<Notification>().Property(n => n.IdVehicle).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Notification>().Property(n => n.Sent).IsRequired();
        modelBuilder.Entity<Notification>().Property(n => n.IdDiagnostic).IsRequired().HasMaxLength(255);
    }
}