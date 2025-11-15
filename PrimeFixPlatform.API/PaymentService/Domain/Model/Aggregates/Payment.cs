using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;

/// <summary>
///     Payment aggregate root entity
/// </summary>
public partial class Payment
{
    /// <summary>
    ///     Private constructor for ORM and serialization purposes
    /// </summary>
    private Payment() { }
    
    /// <summary>
    ///     The constructor for the Payment aggregate root entity
    /// </summary>
    /// <param name="idPayment">
    ///     The unique identifier for the payment
    /// </param>
    /// <param name="cardNumber">
    ///     The cardNumber of the payment
    /// </param>
    /// <param name="cardType">
    ///     The card type of the payment
    /// </param>
    /// <param name="month">
    ///     The month of expiring of the payment
    /// </param>
    /// <param name="year">
    ///     The year of expiring of the payment
    /// </param>
    /// <param name="cvv">
    ///     The cvv of the payment
    /// </param>
    /// <param name="idUserAccount">
    ///     The identifier of the user associated with the payment.
    /// </param>
    public Payment(string idPayment, string cardNumber, ECardType cardType, int month,
        int year, int cvv, string idUserAccount)
    {
        if (cvv < 100 || cvv > 999)
            throw new ArgumentException("CVV must be a 3-digit number between 100 and 999.");

        if (month < 1 || month > 12)
            throw new ArgumentException("Month must be between 1 and 12.");
        
        IdPayment = idPayment;
        CardNumber = cardNumber;
        CardType = cardType;
        Month = month;
        Year = year;
        Cvv = cvv;
        IdUserAccount = idUserAccount;
    }
    
    /// <summary>
    ///     Constructor for the Payment aggregate root entity from CreatePaymentCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing data to create a Payment
    /// </param>
    public Payment(CreatePaymentCommand command): this(
        command.IdPayment,
        command.CardNumber,
        command.CardType,
        command.Month,
        command.Year,
        command.Cvv,
        command.IdUserAccount
        )
    {
    }

    /// <summary>
    ///     Update the payment details based on the UpdatePaymentCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing updated data for the Payment
    /// </param>
    public void UpdatePayment(UpdatePaymentCommand command)
    {
        if (command.Cvv < 100 || command.Cvv > 999)
            throw new ArgumentException("CVV must be a 3-digit number between 100 and 999.");

        if (command.Month < 1 || command.Month > 12)
            throw new ArgumentException("Month must be between 1 and 12.");
        
        IdPayment = command.IdPayment;
        CardNumber = command.CardNumber;
        CardType = command.CardType;
        Month = command.Month;
        Year = command.Year;
        Cvv = command.Cvv;
        IdUserAccount = command.IdUserAccount;
    }
    
    public string IdPayment { get; private set; }
    public string CardNumber { get; private set; }
    public ECardType CardType { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }
    public int Cvv { get; private set; }
    public string IdUserAccount { get; private set; }
    
    
}