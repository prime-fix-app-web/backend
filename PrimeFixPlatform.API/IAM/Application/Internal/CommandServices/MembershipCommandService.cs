using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;

/// <summary>
///     Command service for Membership aggregate
/// </summary>
/// <param name="membershipRepository">
///     The membership repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class MembershipCommandService(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork)
: IMembershipCommandService
{
    /// <summary>
    ///     Handles the command to create a new membership
    /// </summary>
    /// <param name="command">
    ///     The command to create a new membership
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created membership.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a membership with the same IdMembership already exists
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a membership with the same MembershipDescription already exists
    /// </exception>
    public async Task<int> Handle(CreateMembershipCommand command)
    {
        var membership = new Membership(command);
        await membershipRepository.AddAsync(membership);
        await unitOfWork.CompleteAsync();
        return membership.Id;
    }

    /// <summary>
    ///     Handles the command to update an existing membership
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing membership
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated membership.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a membership with the same IdMembership does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a membership with the same MembershipDescription already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the membership to update was not found
    /// </exception>
    public async Task<Membership?> Handle(UpdateMembershipCommand command)
    {
        var membershipId = command.MembershipId;
        
        if (!await membershipRepository.ExistsByMembershipId(membershipId))
            throw new NotFoundIdException("Membership with id " + membershipId  + " does not exist");
        
        var membershipToUpdate = await membershipRepository.FindByIdAsync(membershipId);
        if (membershipToUpdate is null)
            throw new NotFoundArgumentException("Membership not found");
        membershipToUpdate.UpdateMembership(command);
        membershipRepository.Update(membershipToUpdate);
        await unitOfWork.CompleteAsync();
        return membershipToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing membership
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing membership
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating
    ///     whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a membership with the specified IdMembership does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the membership to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteMembershipCommand command)
    {
        if (!await membershipRepository.ExistsByMembershipId(command.MembershipId))
            throw new NotFoundIdException("Membership with id " + command.MembershipId  + " does not exist");
        var membership = await membershipRepository.FindByIdAsync(command.MembershipId);
        if (membership is null)
            throw new NotFoundArgumentException("Membership not found");
        membershipRepository.Remove(membership);
        await unitOfWork.CompleteAsync();
        return true;
    }
}