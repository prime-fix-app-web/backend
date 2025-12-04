namespace PrimeFixPlatform.API.PaymentService.Interfaces.ACL;

public interface IPaymentServiceContextFacade
{
    /// <summary>
    ///     Create a payment
    /// </summary>
    /// <param name="cardNumber">
    ///     Card number of the payment
    /// </param>
    /// <param name="cardType">
    ///     Card type of the payment
    /// </param>
    /// <param name="month">
    ///     Month of expiration of the payment
    /// </param>
    /// <param name="year">
    ///     Year of expiration of the payment
    /// </param>
    /// <param name="cvv">
    ///     Cvv number of the payment
    /// </param>
    /// <param name="idUserAccount">
    ///     Id of the user account associated payment
    /// </param>
    /// <returns>
    ///     The id of the created payment if successful, 0 otherwise
    /// </returns>
    Task<int> CreatePayment(string cardNumber,
        string cardType,
        int month,
        int year,
        int cvv,
        string idUserAccount);
    
    
    /// <summary>
    ///     Fetch the payment by its id
    /// </summary>
    /// <param name="id">
    ///     Id of the payment to fetch
    /// </param>
    /// <returns>
    ///     The id of the profile if found, 0 otherwise
    /// </returns>
    Task<int> FetchPaymentById(int id);
}