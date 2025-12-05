using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;

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
        modelBuilder.Entity<Role>().Property(r => r.Name).HasConversion<string>().HasMaxLength(20).IsRequired().IsUnicode(false);
        
        modelBuilder.Entity<Location>().HasKey(l => l.Id);
        modelBuilder.Entity<Location>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Location>().Property(l => l.Address).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Location>().Property(l => l.District).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Location>().Property(l => l.Department).IsRequired().HasMaxLength(50);
        
        modelBuilder.Entity<Membership>(entity =>
        {
            entity.ToTable("memberships"); 
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Id).HasColumnName("membership_id").ValueGeneratedOnAdd();
            entity.Property(m => m.Started).IsRequired();
            entity.Property(m => m.Over).IsRequired();
            entity.OwnsOne(m => m.MembershipDescription, md =>
            {
                md.Property(p => p.Description).HasColumnName("description").IsRequired().HasMaxLength(250);
            });
        });
    }
}