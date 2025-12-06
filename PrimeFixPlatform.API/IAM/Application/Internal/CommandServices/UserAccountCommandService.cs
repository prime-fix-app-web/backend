using System.Transactions;
using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.ACL;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Hashing;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Tokens;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.IAM.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.IAM.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.IAM.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;

public class UserAccountCommandService(IUserAccountRepository userAccountRepository,
    ILocationCommandService locationCommandService,
    ILocationRepository locationRepository,
    IMembershipCommandService membershipCommandService,
    IMembershipRepository membershipRepository,
    IUserCommandService userCommandService,
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    IExternalAutoRepairCatalogServiceFromIam externalAutoRepairCatalogServiceFromIam,
    IExternalPaymentServiceFromIam externalPaymentServiceFromIam,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork) :  IUserAccountCommandService
{
    /// <summary>
    ///     Handles user sign-in and returns the authenticated user account along with a JWT token.
    /// </summary>
    /// <param name="command">
    ///     The command containing sign-in details
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a tuple with the authenticated UserAccount and a JWT token string.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Indicates that the username or password is invalid
    /// </exception>
    public async Task<(UserAccount userAccount, string token)> Handle(SignInCommand command)
    {
        // Fetch user account by username
        var userAccount = await userAccountRepository.FetchByUsername(command.Username);
        
        // Validate user credentials
        if (userAccount == null || !hashingService.VerifyPassword(command.Password, userAccount.Password))
            throw new ArgumentException("Invalid username or password");
        
        // Generate JWT token
        var token = tokenService.GenerateToken(userAccount);
        return (userAccount, token);
    }

    /// <summary>
    ///     Handles vehicle owner sign-up process
    /// </summary>
    /// <param name="command">
    ///     The command containing sign-up details
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created UserAccount.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Indicates that the username or email already exists, or that related entities could not be created
    /// </exception>
    public async Task<UserAccount?> Handle(VehicleOwnerSignUpCommand command)
    {
        int? paymentId = null;
        // Start a transaction scope
        await using var transaction = await unitOfWork.BeginTransactionAsync();
        try
        {
            // Check for existing username
            if (await userAccountRepository.ExistsByUsername(command.Username))
                throw new ArgumentException("Username already exists");

            // Check for existing email
            if (await userAccountRepository.ExistsByEmail(command.Email))
                throw new ArgumentException("Email already exists");

            // Get role
            var role = await roleRepository.GetByNameAsync(ERole.RoleVehicleOwner)
                       ?? throw new ArgumentException("Role not found");

            // Create location
            var locationId =
                await locationCommandService.Handle(new CreateLocationCommand(command.LocationInformation));

            // Verify location creation
            var location = await locationRepository.FindByIdAsync(locationId)
                           ?? throw new ArgumentException("Location not found");

            // Create membership
            var membershipId = await membershipCommandService.Handle(new CreateMembershipCommand(
                command.MembershipDescription, command.Started, command.Over));

            // Verify membership creation
            var membership = await membershipRepository.FindByIdAsync(membershipId)
                             ?? throw new ArgumentException("Membership not found");

            // Create user
            var userId = await userCommandService.Handle(new CreateUserCommand(command.Name, command.Email, command.Dni,
                command.PhoneNumber, location.Id));

            // Verify user creation
            var user = await userRepository.FindByIdAsync(userId)
                       ?? throw new ArgumentException("User not found");

            var userAccount = new UserAccount(command.Username, command.Email, role.Id, user.Id, membership.Id,
                hashingService.HashPassword(command.Password));
            
            // Commit user account creation
            await userAccountRepository.AddAsync(userAccount);
            await unitOfWork.CompleteAsync(); // Commit changes to get the generated IDs
            await transaction.CommitAsync();
            
            // Set navigation properties
            userAccount.User = user;    
            userAccount.Role = role;
            userAccount.Membership = membership;
            
            // Create payment in external service
            paymentId = await externalPaymentServiceFromIam.CreatePaymentAsync(
                command.CardNumber, command.CardType, command.Month, command.Year, command.Cvv, userAccount.Id);
            if (paymentId == 0)
                throw new ArgumentException("Failed to create payment");
            
            // Return the created user account
            return await userAccountRepository.FetchByUsername(command.Username);
        }
        catch
        {
            // Rollback payment if created
            if (paymentId.HasValue && paymentId.Value != 0)
            {
                // Attempt to delete the payment if it was created
                if (await externalPaymentServiceFromIam.DeletePaymentAsync(paymentId.Value))
                {
                    Console.WriteLine("Rolled back payment with ID: " + paymentId.Value);
                }
                else
                {
                    Console.WriteLine("Failed to delete payment with ID: " + paymentId.Value);
                }
            }
            
            // Rollback transaction
            await transaction.RollbackAsync();
            throw;
        }
    }
        
    public async Task<UserAccount?> Handle(AutoRepairSignUpCommand command)
    {
        int? paymentId = null;
        int? autoRepairId = null;
        // Start a transaction scope
        await using var transaction = await unitOfWork.BeginTransactionAsync();
        try
        {
            // Check for existing username
            if (await userAccountRepository.ExistsByUsername(command.Username))
                throw new ArgumentException("Username already exists");

            // Check for existing email
            if (await userAccountRepository.ExistsByEmail(command.ContactEmail))
                throw new ArgumentException("Email already exists");

            // Get role
            var role = await roleRepository.GetByNameAsync(ERole.RoleAutoRepair)
                       ?? throw new ArgumentException("Role not found");

            // Create location
            var locationId =
                await locationCommandService.Handle(new CreateLocationCommand(command.LocationInformation));

            // Verify location creation
            var location = await locationRepository.FindByIdAsync(locationId)
                           ?? throw new ArgumentException("Location not found");

            // Create membership
            var membershipId = await membershipCommandService.Handle(new CreateMembershipCommand(
                command.MembershipDescription, command.Started, command.Over));

            // Verify membership creation
            var membership = await membershipRepository.FindByIdAsync(membershipId)
                             ?? throw new ArgumentException("Membership not found");

            // Create user
            var userId = await userCommandService.Handle(new CreateUserCommand(command.Username, "Auto Repair",
                "00000000",
                command.PhoneNumber, location.Id));

            // Verify user creation
            var user = await userRepository.FindByIdAsync(userId)
                       ?? throw new ArgumentException("User not found");

            // Create user account
            var userAccount = new UserAccount(command.Username, command.ContactEmail, role.Id, user.Id, membership.Id,
                hashingService.HashPassword(command.Password));

            await userAccountRepository.AddAsync(userAccount);
            
            // Commit changes to get the generated IDs
            await unitOfWork.CompleteAsync(); // Commit changes to get the generated IDs
            await transaction.CommitAsync();
            
            // Set navigation properties
            userAccount.User = user;    
            userAccount.Role = role;
            userAccount.Membership = membership;
            
            // Create payment
            paymentId = await externalPaymentServiceFromIam.CreatePaymentAsync(
                command.CardNumber, command.CardType, command.Month, command.Year, command.Cvv, userAccount.Id);
            // Verify payment creation
            if (paymentId == 0)
                throw new ArgumentException("Failed to create payment");
            
            // Create auto repair
            autoRepairId = await externalAutoRepairCatalogServiceFromIam.CreateAutoRepairAsync(
                command.ContactEmail, command.Ruc, userAccount.Id);
            
            // Verify auto repair creation
            if (autoRepairId == 0)
                throw new ArgumentException("Failed to create auto repair");
            
            // Return the created user account
            return await userAccountRepository.FetchByUsername(command.Username);
        }
        catch
        {
            // Rollback payment if created
            if (paymentId.HasValue && paymentId.Value != 0)
            {
                // Attempt to delete the payment if it was created
                if (await externalPaymentServiceFromIam.DeletePaymentAsync(paymentId.Value))
                {
                    Console.WriteLine("Rolled back payment with ID: " + paymentId.Value);
                }
                else
                {
                    Console.WriteLine("Failed to delete payment with ID: " + paymentId.Value);
                }
            }
            
            // Rollback auto repair if created
            if (autoRepairId.HasValue && autoRepairId.Value != 0)
            {
                // Attempt to delete the auto repair if it was created
                if (await externalAutoRepairCatalogServiceFromIam.DeleteAutoRepairAsync(autoRepairId.Value))
                {
                    Console.WriteLine("Rolled back auto repair with ID: " + autoRepairId.Value);
                }
                else
                {
                    Console.WriteLine("Failed to delete auto repair with ID: " + autoRepairId.Value);
                }
            }
            
            // Rollback transaction
            await transaction.RollbackAsync();
            throw;
        }
    }

        /// <summary>
    ///     Handles the command to create a new user account
    /// </summary>
    /// <param name="command">
    ///     The command to create a new user account
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created user account.
    /// </returns>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user, role, or membership with the specified ID does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a user account with the same UserAccountId, Username or Email already exists
    /// </exception>
    public async Task<int> Handle(CreateUserAccountCommand command)
    {
        // Validate user existence
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null)
            throw new NotFoundArgumentException("User not found with the given id " + command.UserId);
        
        // Validate role existence
        var role = await roleRepository.FindByIdAsync(command.RoleId);
        if (role == null)
            throw new NotFoundArgumentException("Role not found with the given id " + command.RoleId);
        
        // Validate membership existence
        var membership = await membershipRepository.FindByIdAsync(command.MembershipId);
        if (membership == null)
            throw new NotFoundArgumentException("Membership not found with the given id " + command.MembershipId);
        
        var username = command.Username;
        var email = command.Email;
        
        // Check for existing username
        if (await userAccountRepository.ExistsByUsername(username))
            throw new ConflictException("UserAccount with the same username " + username + " already exists");
        
        // Check for existing email
        if (await userAccountRepository.ExistsByEmail(email))
            throw new ConflictException("UserAccount with the same email " + email + " already exists");
        
        var userAccount = new UserAccount(command);
        await userAccountRepository.AddAsync(userAccount);
        await unitOfWork.CompleteAsync();
        userAccount.User = user;
        userAccount.Role = role;
        userAccount.Membership = membership;
        return userAccount.Id;
    }

    /// <summary>
    ///     Handles the command to update an existing user account
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing user account
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated user account.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the user account with the specified IdUserAccount does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that another user account with the same Username or Email already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user account with the specified IdUserAccount was not found
    /// </exception>
    public async Task<UserAccount?> Handle(UpdateUserAccountCommand command)
    {
        var userAccountId = command.UserAccountId;
        var username = command.Username;
        var email = command.Email;
        
        if (!await userAccountRepository.ExistsByUserAccountId(userAccountId)) 
            throw new NotFoundIdException("UserAccount with id " + userAccountId + " not found");
        
        if (await userAccountRepository.ExistsByUsernameAndUserAccountIdIsNot(username, userAccountId))
            throw new ConflictException("UserAccount with the same username " + username + " already exists");
        
        if (await userAccountRepository.ExistsByEmailAndUserAccountIdIsNot(email, userAccountId))
            throw new ConflictException("UserAccount with the same email " + email + " already exists");
        
        var userAccountToUpdate = await userAccountRepository.FindByIdAsync(userAccountId);
        if (userAccountToUpdate == null)
            throw new NotFoundArgumentException("UserAccount not found");
        
        userAccountToUpdate.UpdateUserAccount(command);
        userAccountRepository.Update(userAccountToUpdate);
        await unitOfWork.CompleteAsync();
        return userAccountToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete a user account
    /// </summary>
    /// <param name="command">
    ///     The command to delete a user account
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating
    ///     whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the user account with the specified IdUserAccount does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user account with the specified IdUserAccount was not found
    /// </exception>
    public async Task<bool> Handle(DeleteUserAccountCommand command)
    {
        if (!await userAccountRepository.ExistsByUserAccountId(command.UserAccountId)) 
            throw new NotFoundIdException("UserAccount with id " + command.UserAccountId + " not found");
        var userAccount = await userAccountRepository.FindByIdAsync(command.UserAccountId);
        if (userAccount == null)
            throw new NotFoundArgumentException("UserAccount not found");
        userAccountRepository.Remove(userAccount);
        await unitOfWork.CompleteAsync();
        return true;
    }
}