using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.Iam.Domain.Model.Commands;

/// <summary>
///     Command to sign up a new vehicle owner
/// </summary>
/// <param name="Name">
///     The first name of the vehicle owner.
/// </param>
/// <param name="LastName">
///     The last name of the vehicle owner.
/// </param>
/// <param name="Dni">
///     The DNI (identification number) of the vehicle owner.
/// </param>
/// <param name="PhoneNumber">
///     The phone number of the vehicle owner.
/// </param>
/// <param name="Username">
///     The username for the vehicle owner's account.
/// </param>
/// <param name="Email">
///     The email address of the vehicle owner.
/// </param>
/// <param name="Password">
///     The password for the vehicle owner's account.
/// </param>
/// <param name="LocationInformation">
///     The location information of the vehicle owner.
/// </param>
/// <param name="MembershipDescription">
///     The membership description for the vehicle owner.
/// </param>
/// <param name="Started">
///     The start date of the vehicle owner's membership.
/// </param>
/// <param name="Over">
///     The end date of the vehicle owner's membership.
/// </param>
/// <param name="CardNumber">
///     The card number for the vehicle owner's payment method.
/// </param>
/// <param name="CardType">
///     The type of card for the vehicle owner's payment method.
/// </param>
/// <param name="Month">
///     The expiration month of the vehicle owner's card.
/// </param>
/// <param name="Year">
///     The expiration year of the vehicle owner's card.
/// </param>
/// <param name="Cvv">
///     The CVV code of the vehicle owner's card.
/// </param>
public record VehicleOwnerSignUpCommand(string Name,
                                        string LastName,
                                        string Dni,
                                        string PhoneNumber,
                                        string Username,
                                        string Email,
                                        string Password,
                                        LocationInformation LocationInformation,
                                        MembershipDescription MembershipDescription,
                                        DateOnly Started,
                                        DateOnly Over,
                                        string CardNumber,
                                        CardType CardType,
                                        int Month,
                                        int Year,
                                        int Cvv);