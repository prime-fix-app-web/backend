using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;

namespace PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Tokens;

/**
 * <summary>
 *     The token service interface
 * </summary>
 * <remarks>
 *     This interface is used to generate and validate JWT tokens
 * </remarks>
 */
public interface ITokenService
{
    /**
     * <summary>
     *     Generate a JWT token
     * </summary>
     * <param name="userAccount">The user account to generate the token for</param>
     * <returns>The generated token</returns>
     */
    string GenerateToken(UserAccount userAccount);

    /**
     * <summary>
     *     Validate a JWT token
     * </summary>
     * <param name="token">The token to validate</param>
     * <returns>The user id if the token is valid, null otherwise</returns>
     */
    Task<int?> ValidateToken(string token);
}