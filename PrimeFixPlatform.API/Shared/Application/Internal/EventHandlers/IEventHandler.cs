using Cortex.Mediator.Notifications;
using PrimeFixPlatform.API.Shared.Domain.Model.Events;

namespace PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}