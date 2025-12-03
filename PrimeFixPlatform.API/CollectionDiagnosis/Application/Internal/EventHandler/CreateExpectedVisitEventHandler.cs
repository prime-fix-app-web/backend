using Humanizer;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Entities;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Events;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Application.Internal.EventHandlers;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.EventHandler;

public class CreateExpectedVisitEventHandler :IEventHandler<CreateExpectedVisitEvent>
{
    private readonly IExpectedVisitRepository _expectedVisitRepository;
    private readonly IVisitRepository _visitRepository;
    private readonly IUnitOfWork _unitOfWork;
    

    public CreateExpectedVisitEventHandler(IVisitRepository visitRepository,IExpectedVisitRepository expectedVisitRepository, IUnitOfWork unitOfWork)
    {
        _visitRepository = visitRepository;
        _expectedVisitRepository = expectedVisitRepository;
        _unitOfWork = unitOfWork;
    }
    
    public Task Handle(CreateExpectedVisitEvent notification, CancellationToken cancellationToken)
    {
        return On(notification, cancellationToken);
    }

    private async Task On(CreateExpectedVisitEvent domainEvent, CancellationToken ct)
    {
        var expectedVisit = new ExpectedVisit(domainEvent.Status, domainEvent.VisitId, domainEvent.IsScheduled);
        
        await _expectedVisitRepository.AddAsync(expectedVisit);
        await _unitOfWork.CompleteAsync();
    }
}