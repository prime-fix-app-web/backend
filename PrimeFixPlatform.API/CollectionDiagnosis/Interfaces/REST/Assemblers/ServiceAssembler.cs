using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.REST.Assemblers;

public class ServiceAssembler
{
    public static CreateServiceCommand ToCommandFromRequest(CreateServiceRequest request)
    {
        return new CreateServiceCommand(request.Name, request.Description);
    }

    public static UpdateServiceCommand ToCommandFromRequest(UpdateServiceCommand request)
    {
        return new UpdateServiceCommand(request.ServiceId,request.Name, request.Description);
    }

    public static ServiceResponse ToResponseFromEntity(Service entity)
    {
        return new ServiceResponse(entity.Id, entity.Name, entity.Description);
    }
}