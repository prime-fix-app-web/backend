using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.AutorepairRegister.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Extensions for configuring the ModelBuilder for the Autorepair Register Bounded Context.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the Autorepair Register configuration to the ModelBuilder.
    /// </summary>
    /// <param name="modelBuilder">
    ///     The ModelBuilder to configure.
    /// </param>
    public static void ApplyAutorepairRegisterConfiguration(this ModelBuilder modelBuilder)
    {
        // Autorepair Register Bounded Context
        modelBuilder.Entity<Technician>().HasKey(t => t.Id);
        modelBuilder.Entity<Technician>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Technician>().Property(t => t.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Technician>().Property(t => t.LastName).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Technician>().Property(t => t.AutoRepairId).IsRequired();

        modelBuilder.Entity<TechnicianSchedule>().HasKey(ts => ts.Id);
        modelBuilder.Entity<TechnicianSchedule>().Property(ts => ts.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<TechnicianSchedule>().Property(ts => ts.TechnicianId).IsRequired();
        modelBuilder.Entity<TechnicianSchedule>().Property(ts => ts.DayOfWeek).IsRequired().HasMaxLength(15);
        modelBuilder.Entity<TechnicianSchedule>().Property(ts => ts.StartTime).IsRequired().HasColumnType("time");
        modelBuilder.Entity<TechnicianSchedule>().Property(ts => ts.EndTime).IsRequired().HasColumnType("time");
        modelBuilder.Entity<TechnicianSchedule>().Property(ts => ts.IsActive).IsRequired();
    }
}