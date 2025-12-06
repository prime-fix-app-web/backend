namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;

/// <summary>
///     Enumeration representing the state of a visit
/// </summary>
/// <remarks>
///     Does not match the rule for enums, but is required to match external system values
/// </remarks>
public enum EStateVisit
{
    SCHEDULED_VISIT,
    PENDING_VISIT,
    CANCELLED_VISIT
}