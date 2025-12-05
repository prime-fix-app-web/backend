using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting authentication-related requests into commands.
/// </summary>
public static class AuthenticationAssembler
{
    /// <summary>
    ///     Converts a SignInRequest into a SignInCommand.
    /// </summary>
    /// <param name="request">
    ///     The sign-in request containing user credentials.
    /// </param>
    /// <returns>
    ///     The corresponding SignInCommand.
    /// </returns>
    public static SignInCommand ToCommandFromRequestSignIn(SignInRequest request)
    {
        return new SignInCommand(
            request.Username, request.Password
        );
    }

    /// <summary>
    ///     Converts a VehicleOwnerSignUpRequest into a VehicleOwnerSignUpRequest command.
    /// </summary>
    /// <param name="request">
    ///     The vehicle owner sign-up request containing user details.
    /// </param>
    /// <returns>
    ///     The corresponding VehicleOwnerSignUpRequest command.
    /// </returns>
    public static VehicleOwnerSignUpCommand ToCommandFromRequestSignUpVehicleOwner(VehicleOwnerSignUpRequest request)
    {
        return new VehicleOwnerSignUpCommand(
            request.Name,
            request.LastName,
            request.Dni,
            request.PhoneNumber,
            request.Username,
            request.Email,
            request.Password,
            new LocationInformation(request.Address, request.District, request.Department),
            new MembershipDescription(request.MembershipDescription),
            request.Started,
            request.Over,
            request.CardNumber,
            new CardType(request.CardType),
            request.Month,
            request.Year,
            request.Cvv
        );
    }
    
    public static AuthenticatedUserAccountResponse ToResponseFromEntityUserAccount(UserAccount entity, string token)
    {
        return new AuthenticatedUserAccountResponse(entity.Id, entity.Username, token);
    }
}