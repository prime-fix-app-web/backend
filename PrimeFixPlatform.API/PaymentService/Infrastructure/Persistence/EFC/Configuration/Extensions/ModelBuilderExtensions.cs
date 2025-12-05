using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.PaymentService.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Extensions for configuring the ModelBuilder for the PaymentService Bounded Context
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the PaymentService configuration to the ModelBuilder
    /// </summary>
    /// <param name="modelBuilder">
    ///     The ModelBuilder to configure
    /// </param>
    public static void ApplyPaymentServiceConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
        modelBuilder.Entity<Payment>().Property(p => p.PaymentId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Payment>().Property(p => p.CardNumber).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Payment>().OwnsOne(p => p.CardType, ct =>
        {
            ct.WithOwner().HasForeignKey("PaymentIdPayment");
            ct.Property<int>("PaymentIdPayment").HasColumnName("payment_id");
            ct.Property(p => p.Type).IsRequired().HasMaxLength(50);
        });
        modelBuilder.Entity<Payment>().Property(p => p.Cvv).IsRequired();
        modelBuilder.Entity<Payment>().Property(p => p.UserAccountId).IsRequired();
        modelBuilder.Entity<Payment>().Property(p => p.Month).IsRequired();
        modelBuilder.Entity<Payment>().Property(p => p.Year).IsRequired();
        
        
        modelBuilder.Entity<Rating>().HasKey(r => r.RatingId);
        modelBuilder.Entity<Rating>().Property(r => r.RatingId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Rating>().Property(r => r.StarRating).IsRequired();
        modelBuilder.Entity<Rating>().Property(r => r.Comment).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<Rating>().Property(r => r.AutoRepairId).IsRequired();
        modelBuilder.Entity<Rating>().Property(r => r.UserAccountId).IsRequired();

    }
}