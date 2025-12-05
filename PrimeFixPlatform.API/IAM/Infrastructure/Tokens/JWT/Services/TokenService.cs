using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Tokens;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;

namespace PrimeFixPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;

/**
 * <summary>
 *     The token service
 * </summary>
 * <remarks>
 *     This class is used to generate and validate tokens
 * </remarks>
 */
public class TokenService(IOptions<TokenSettings> tokenSettings) : ITokenService
{
    private readonly TokenSettings _tokenSettings = tokenSettings.Value;

    /**
     * <summary>
     *     Generate token
     * </summary>
     * <param name="userAccount">The user account for token generation</param>
     * <returns>The generated Token</returns>
     */
    public string GenerateToken(UserAccount userAccount)
    {
        var key = Encoding.UTF8.GetBytes(_tokenSettings.Secret);

        // Build claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, userAccount.Id.ToString()),
            new Claim(ClaimTypes.Name, userAccount.Username)
        };
        
        claims.Add(new Claim(ClaimTypes.Role, userAccount.Role.Name.ToString()));

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_tokenSettings.ExpirationInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    /**
     * <summary>
     *     Validate token
     * </summary>
     * <param name="token">The token to validate</param>
     * <returns>The user id if the token is valid, null otherwise</returns>
     */
    public Task<int?> ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return Task.FromResult<int?>(null);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_tokenSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _tokenSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _tokenSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            int userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.Sid).Value);

            return Task.FromResult<int?>(userId);
        }
        catch
        {
            return Task.FromResult<int?>(null);
        }
    }
}