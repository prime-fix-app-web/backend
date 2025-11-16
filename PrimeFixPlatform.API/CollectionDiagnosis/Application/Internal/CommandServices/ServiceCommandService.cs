using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.CommandServices;
/// <summary>
/// Command service of service aggregate
/// </summary>
/// <param name="serviceRepository">
///     The service repository
/// </param>
/// <param name="unitOfWork">
/// Unit of work
/// </param>
public class ServiceCommandService(IServiceRepository serviceRepository,IUnitOfWork unitOfWork) : IServiceCommandService
{
    /// <summary>
    ///      Handles the command to create a new Service
    /// </summary>
    /// <param name="command">
    ///     The command to create a new service
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contain the created service
    /// </returns>
    public async Task<Service?> Handle(CreateServiceCommand command)
    {
        var service = new Service(command);
        await serviceRepository.AddAsync(service);
        await unitOfWork.CompleteAsync();
        return service;
    }

    /// <summary>
    ///     Handles the command to update an existing service
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing service
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronouns operation.The task result contain the updated service
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the service with the specified Service
    /// </exception>
    public async Task<Service?> Handle(UpdateServiceCommand command)
    {
        var serviceId = command.ServiceId;
        var serviceToUpdate = await serviceRepository.FindByIdAsync(serviceId);
        if (serviceToUpdate == null)
        {
            throw new NotFoundArgumentException("Service not found");
        }
        serviceToUpdate.UpdateService(command);
        serviceRepository.Update(serviceToUpdate);
        await unitOfWork.CompleteAsync();
        return serviceToUpdate;
    }
    
    /// <summary>
    /// Handles the command to delete a service
    /// </summary>
    /// <param name="command">
    ///     The command to delete a service
    /// </param>
    /// <returns>
    ///     A task that represnets the asynchronous operation. The task result contains the deleted servoce
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user with specified ServiceID was not found 
    /// </exception>
    public async Task<Service?> Handle(DeleteServiceCommand command)
    {
        var service = await serviceRepository.FindByIdAsync(command.ServiceId);
        if (service == null)
            throw new NotFoundArgumentException("Service not found");
        serviceRepository.Remove(service);
        await unitOfWork.CompleteAsync();
        return service;
    }
}