using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Payment-related requests, commands, and responses
/// </summary>
public class PaymentAssembler
{
    /// <summary>
    ///     Converts a CreatePaymentRequest to a CreatePaymentCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreatePaymentRequest containing payment details.
    /// </param>
    /// <returns>
    ///     The corresponding CreatePaymentCommand.
    /// </returns>
    public static CreatePaymentCommand ToCommandFromRequest(CreatePaymentRequest request)
    {
        return new CreatePaymentCommand(
                request.IdPayment, request.CardNumber, new CardType(request.CardType), request.Month,
                request.Year, request.Cvv, request.IdUserAccount
                );
    }
    
    /// <summary>
    ///     Converts an UpdatePaymentRequest to an UpdatePaymentCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdatePaymentRequest containing updated payment details.
    /// </param>
    /// <param name="idPayment">
    ///     The identifier of the payment to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdatePaymentCommand.
    /// </returns>
    public static UpdatePaymentCommand ToCommandFromRequest(UpdatePaymentRequest request, string idPayment)
    {
        return new UpdatePaymentCommand(
            idPayment, request.CardNumber, new CardType(request.CardType), request.Month,
            request.Year, request.Cvv, request.IdUserAccount
        );
    }

    /// <summary>
    ///     Converts a Payment entity to a PaymentResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Payment entity containing payment details.
    /// </param>
    /// <returns>
    ///     The corresponding PaymentResponse.
    /// </returns>
    public static PaymentResponse ToResponseFromEntity(Payment entity)
    {
        return new PaymentResponse(
            entity.IdPayment, entity.CardNumber, entity.CardType.Type, entity.Month,
            entity.Year, entity.Cvv, entity.IdUserAccount
        );
    }
    
}