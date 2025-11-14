using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder modelBuilder)
    {
        // Iam Context
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
    }
}