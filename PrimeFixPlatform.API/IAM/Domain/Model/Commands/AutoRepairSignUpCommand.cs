using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to sign up a new auto repair
/// </summary>
/// <param name="AutoRepairName">
///     The name of the auto repair.
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the auto repair.
/// </param>
/// <param name="Username">
///     The username for the auto repair's account.
/// </param>
/// <param name="Email">
///     The email address of the auto repair.
/// </param>
/// <param name="Password">
///     The password for the auto repair's account.
/// </param>
/// <param name="ContactEmail">
///     The contact email of the auto repair.
/// </param>
/// <param name="Ruc">
///     The RUC (tax identification number) of the auto repair.
/// </param>
/// <param name="LocationInformation">
///     The location information of the auto repair.
/// </param>
/// <param name="MembershipDescription">
///     The membership description for the auto repair.
/// </param>
/// <param name="Started">
///     The start date of the auto repair's membership.
/// </param>
/// <param name="Over">
///     The end date of the auto repair's membership.
/// </param>
/// <param name="CardNumber">
///     The card number for the auto repair's payment method.
/// </param>
/// <param name="CardType">
///     The type of card for the auto repair's payment method.
/// </param>
/// <param name="Month">
///     The expiration month of the auto repair's card.
/// </param>
/// <param name="Year">
///     The expiration year of the auto repair's card.
/// </param>
/// <param name="Cvv">
///     The CVV code of the auto repair's card.
/// </param>
public record AutoRepairSignUpCommand(string AutoRepairName,
                                      string PhoneNumber,
                                      string Username,
                                      string Email,
                                      string Password,
                                      string ContactEmail,
                                      string Ruc,
                                      LocationInformation LocationInformation,
                                      MembershipDescription MembershipDescription,
                                      DateOnly Started,
                                      DateOnly Over,
                                      string CardNumber,
                                      CardType CardType,
                                      int Month,
                                      int Year,
                                      int Cvv);