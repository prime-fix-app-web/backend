namespace PrimeFixPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;

/**
 * <summary>
 *     This class is used to store the token settings.
 *     It is used to configure the token settings in the app settings .json file.
 * </summary>
 */
public class TokenSettings
{
    /// <summary>
    ///     The secret key used to sign the JWT tokens.
    /// </summary>
    public string Secret { get; set; } = string.Empty;
    
    /// <summary>
    /// The issuer of the token (who generated it).
    /// </summary>
    public string Issuer { get; set; } = string.Empty;
    
    /// <summary>
    /// The audience for which the token is intended (who can use it).
    /// </summary>
    public string Audience { get; set; } = string.Empty;
    
    /// <summary>
    /// Expiration time in minutes.
    /// </summary>
    public int ExpirationInMinutes { get; set; }
}