using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;

/// <summary>
///     Event triggered when a diagnostic is registered for a vehicle.
/// </summary>
/// <param name="VehicleId">
///     The identifier of the vehicle for which the diagnostic is registered.
/// </param>
/// <param name="Diagnosis">
///     The details of the registered diagnostic.
/// </param>
public sealed record DiagnosticRegisteredEvent(int VehicleId, string Diagnosis) : IEvent;