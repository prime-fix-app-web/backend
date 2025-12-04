using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Extensions for configuring the ModelBuilder for the Iam bounded context
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the Iam bounded context configuration to the ModelBuilder
    /// </summary>
    /// <param name="modelBuilder">
    ///     The ModelBuilder to configure
    /// </param>
    public static void ApplyIamConfiguration(this ModelBuilder modelBuilder)
    {
        // Iam Bounded Context
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().Property(u => u.Dni).IsRequired().HasMaxLength(8);
        modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
        modelBuilder.Entity<User>().Property(u => u.LocationId).IsRequired();

        modelBuilder.Entity<UserAccount>().HasKey(ua => ua.Id);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Username).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Email).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.RoleId).IsRequired();
        modelBuilder.Entity<UserAccount>().Property(ua => ua.UserId).IsRequired();
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Password).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.IsNew).IsRequired();
        
        modelBuilder.Entity<Role>().HasKey(r => r.Id);
        modelBuilder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Role>().OwnsOne(r => r.RoleInformation, ri =>
        {
            ri.WithOwner().HasForeignKey("RoleId");
            ri.Property<string>("RoleId").HasColumnName("role_id");
            ri.Property(p => p.Name).IsRequired().HasMaxLength(100);
            ri.Property(p => p.Description).IsRequired().HasMaxLength(250);
        });
        
        modelBuilder.Entity<Membership>().HasKey(m => m.Id);
        modelBuilder.Entity<Membership>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Membership>().Property(m => m.Started).IsRequired();
        modelBuilder.Entity<Membership>().Property(m => m.Over).IsRequired();
        modelBuilder.Entity<Membership>().OwnsOne(m => m.MembershipDescription, md =>
        {
            md.WithOwner().HasForeignKey("MembershipId");
            md.Property<string>("MembershipId").HasColumnName("membership_id");
            md.Property(p => p.Description).IsRequired().HasMaxLength(250);
        });
    }
}