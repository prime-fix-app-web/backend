using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.AutorepairRegister.Domain.Model.Events;

/// <summary>
///     Event triggered when a technician is deleted.
/// </summary>
/// <param name="AutoRepairId">
///     The identifier of the auto repair associated with the deleted technician.
/// </param>
public sealed record TechnicianDeletedEvent(int AutoRepairId) : IEvent;