using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;

/// <summary>
///     Event triggered when a technician is registered.
/// </summary>
/// <param name="AutoRepairId">
///     The identifier of the auto repair associated with the registered technician.
/// </param>
public sealed record TechnicianRegisteredEvent(int AutoRepairId) : IEvent;