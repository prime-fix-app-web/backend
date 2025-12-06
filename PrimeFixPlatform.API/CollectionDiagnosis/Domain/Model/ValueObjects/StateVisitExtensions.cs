namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

/// <summary>
///     Extension methods for the EStateVisit enum
/// </summary>
public static class StateVisitExtensions
{
    /// <summary>
    ///     Gets a notification message based on the state of the visit
    /// </summary>
    /// <param name="state">
    ///     The state of the visit
    /// </param>
    /// <returns>
    ///     The notification message corresponding to the state
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     In case of an invalid StateVisit value
    /// </exception>
    public static string GetNotificationMessage(this EStateVisit state)
        => state switch
        {
            EStateVisit.SCHEDULED_VISIT => "Your visit has been scheduled.",
            EStateVisit.PENDING_VISIT   => "Your visit is pending.",
            EStateVisit.CANCELLED_VISIT => "Your visit has been cancelled.",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid StateVisit value.")
        };

    /// <summary>
    ///     Converts a string to the corresponding EStateVisit enum value
    /// </summary>
    /// <param name="value">
    ///     The string representation of the state visit
    /// </param>
    /// <returns>
    ///     The corresponding EStateVisit enum value
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     In case of an invalid StateVisit string value
    /// </exception>
    public static EStateVisit ToStateVisit(string value)
    {
        if (!Enum.TryParse<EStateVisit>(value, true, out var result))
        {
            throw new ArgumentException($"Invalid StateVisit value: {value}", nameof(value));
        }
        return result;
    }
}