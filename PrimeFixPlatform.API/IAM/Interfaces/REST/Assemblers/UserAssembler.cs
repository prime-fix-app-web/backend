using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

public class UserAssembler
{
    public static CreateUserCommand ToCommandFromRequest(CreateUserRequest request)
    {
        return new CreateUserCommand(
            request.IdUser, request.Name, request.LastName,
            request.Dni, request.PhoneNumber, request.IdLocation
        );
    }
    
    public static UpdateUserCommand ToCommandFromRequest(UpdateUserRequest request, string idUser)
    {
        return new UpdateUserCommand(
            idUser, request.Name, request.LastName,
            request.Dni, request.PhoneNumber, request.IdLocation
        );
    }

    public static UserResponse ToResponseFromEntity(User entity)
    {
        return new UserResponse(
            entity.IdUser, entity.Name, entity.LastName,
            entity.Dni, entity.PhoneNumber, entity.IdLocation
        );
    }
}