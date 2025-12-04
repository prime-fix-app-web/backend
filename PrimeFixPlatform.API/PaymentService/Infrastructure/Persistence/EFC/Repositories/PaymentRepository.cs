using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.PaymentService.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Payment entities
/// </summary>
/// <param name="context"></param>
public class PaymentRepository(AppDbContext context)
: BaseRepository<Payment>(context), IPaymentRepository
{
    /// <summary>
    ///     Checks if a payment exists by its unique identifier
    /// </summary>
    /// <param name="idPayment">
    ///     The unique identifier of the payment
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a payment with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdPayment(int idPayment)
    {
        return await Context.Set<Payment>().AnyAsync(payment => payment.PaymentId == idPayment);
    }
    
    /// <summary>
    ///     Checks if a payment exists by the user account ID.
    /// </summary>
    /// <param name="idUserAccount">
    ///     The user account ID to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a payment with the specified user account ID exists.
    /// </returns>
    public async Task<bool> ExistsByIdUserAccount(int idUserAccount)
    {
        return await Context.Set<Payment>().AnyAsync(payment => payment.UserAccountId == idUserAccount);
    }

    /// <summary>
    ///     Checks if a payment exists by the user account ID, excluding a specific vehicle by its ID.
    /// </summary>
    /// <param name="idUserAccount">
    ///     The user account ID to check for existence.
    /// </param>
    /// <param name="idPayment">
    ///     The unique identifier of the payment to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a payment with the specified user account ID exists,
    ///     excluding the payment with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByIdUserAccountAndIdPaymentIsNot(int idUserAccount, int idPayment)
    {
        return await Context.Set<Payment>().AnyAsync(payment =>
            payment.UserAccountId == idUserAccount && payment.PaymentId != idPayment);
    }

    /// <summary>
    ///     Finds payments by their maintenance status.
    /// </summary>
    /// <param name="idUserAccount">
    ///     The user account ID to filter payments by.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of payments with the specified user account ID.
    /// </returns>
    public async Task<IEnumerable<Payment>> FindByIdUserAccount(int idUserAccount)
    {
        return await Context.Set<Payment>()
            .Where(payment => payment.UserAccountId == idUserAccount)
            .ToListAsync();
    }
}