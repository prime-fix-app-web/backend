using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

/// <summary>
///     Event triggered when the state of a visit is changed.
/// </summary>
/// <param name="VehicleId">
///     The identifier of the vehicle associated with the visit.
/// </param>
/// <param name="StateVisit">
///     The new state of the visit.
/// </param>
public sealed record ChangeStateVisitEvent(int VehicleId, EStateVisit StateVisit): IEvent;