using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;

/// <summary>
///     Event triggered when a technician is registered.
/// </summary>
/// <param name="autoRepairId">
///     The identifier of the auto repair associated with the registered technician.
/// </param>
public class TechnicianRegisteredEvent(int autoRepairId) : IEvent
{
    public int AutoRepairId { get; } = autoRepairId;
}