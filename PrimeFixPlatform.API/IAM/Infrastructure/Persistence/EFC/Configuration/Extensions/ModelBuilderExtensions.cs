using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder modelBuilder)
    {
        // Iam Bounded Context
        modelBuilder.Entity<User>().HasKey(u => u.IdUser);
        modelBuilder.Entity<User>().Property(u => u.IdUser).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<User>().Property(u => u.Dni).IsRequired().HasMaxLength(8);
        modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
        modelBuilder.Entity<User>().Property(u => u.IdLocation).IsRequired().HasMaxLength(255);

        modelBuilder.Entity<UserAccount>().HasKey(ua => ua.IdUserAccount);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.IdUserAccount).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Username).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Email).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.IdRole).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.IdUser).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.Password).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserAccount>().Property(ua => ua.IsNew).IsRequired();
        
        modelBuilder.Entity<Role>().HasKey(r => r.IdRole);
        modelBuilder.Entity<Role>().Property(r => r.IdRole).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Role>().OwnsOne(r => r.RoleInformation, ri =>
        {
            ri.WithOwner().HasForeignKey("RoleIdRole");
            ri.Property<string>("RoleIdRole").HasColumnName("id_role");
            ri.Property(p => p.Name).IsRequired().HasMaxLength(100);
            ri.Property(p => p.Description).IsRequired().HasMaxLength(250);
        });
    }
}