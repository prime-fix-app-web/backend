namespace PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Represents a role in the system
/// </summary>
public interface IRole
{
    /// <summary>
    ///     Gets the string representation of the role name
    /// </summary>
    /// <returns>
    ///     The string name of the role
    /// </returns>
    string GetStringName();
}