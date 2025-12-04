using Humanizer;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.EventHandler;

/// <summary>
///     Domain event handler responsible for processing
///     <see cref="CreateExpectedVisitEvent"/> events.
///     
///     This handler automatically creates a new <see cref="ExpectedVisit"/>
///     entity whenever a related visit is created in the system.
/// </summary>
public class CreateExpectedVisitEventHandler :IEventHandler<CreateExpectedVisitEvent>
{
    private readonly IExpectedVisitRepository _expectedVisitRepository;
    private readonly IVisitRepository _visitRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="CreateExpectedVisitEventHandler"/> class.
    /// </summary>
    /// <param name="visitRepository">
    ///     Repository for accessing visit entities.
    /// </param>
    /// <param name="expectedVisitRepository">
    ///     Repository used to persist expected visit entities.
    /// </param>
    /// <param name="unitOfWork">
    ///     Unit of work responsible for managing transactional consistency.
    /// </param>
    public CreateExpectedVisitEventHandler(IVisitRepository visitRepository,IExpectedVisitRepository expectedVisitRepository, IUnitOfWork unitOfWork)
    {
        _visitRepository = visitRepository;
        _expectedVisitRepository = expectedVisitRepository;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    ///     Handles the incoming <see cref="CreateExpectedVisitEvent"/>
    ///     notification received from the event dispatcher.
    /// </summary>
    /// <param name="notification">
    ///     Event carrying the data required to create the expected visit.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token used to cancel the asynchronous operation if needed.
    /// </param>
    
    public Task Handle(CreateExpectedVisitEvent notification, CancellationToken cancellationToken)
    {
        return On(notification, cancellationToken);
    }

    /// <summary>
    ///     Processes the domain event and persists the new
    ///     <see cref="ExpectedVisit"/> entity.
    /// </summary>
    /// <param name="domainEvent">
    ///     The domain event that triggered the creation process.
    /// </param>
    /// <param name="ct">
    ///     Cancellation token.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation.
    /// </returns>
    private async Task On(CreateExpectedVisitEvent domainEvent, CancellationToken ct)
    {
        var expectedVisit = new ExpectedVisit(domainEvent.Status, domainEvent.VisitId, domainEvent.IsScheduled);
        
        await _expectedVisitRepository.AddAsync(expectedVisit);
        await _unitOfWork.CompleteAsync();
    }
}