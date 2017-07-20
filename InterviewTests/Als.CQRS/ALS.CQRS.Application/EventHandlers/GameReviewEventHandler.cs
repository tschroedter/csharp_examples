using ALS.CQRS.Contracts.Events;
using ALS.CQRS.DataAccess.ReadModels;
using JetBrains.Annotations;
using SimpleCqrs.Eventing;

namespace ALS.CQRS.Application.EventHandlers
{
    [UsedImplicitly]
    public class GameReviewEventHandler
        : IHandleDomainEvents <GameReviewCreatedEvent>,
          IHandleDomainEvents <GameReviewTitleChangedEvent>,
          IHandleDomainEvents <GameReviewDescriptionChangedEvent>,
          IHandleDomainEvents <GameReviewRatingChangedEvent>
    {
        public GameReviewEventHandler(
            [NotNull] IGameReviesReadModel readModel)
        {
            m_ReadModel = readModel;
        }

        private readonly IGameReviesReadModel m_ReadModel;

        public void Handle(GameReviewCreatedEvent createdEvent)
        {
            m_ReadModel.Add(new GameReview
                            {
                                Id = createdEvent.AggregateRootId,
                                Title = createdEvent.Title,
                                Description = createdEvent.Description,
                                Rating = createdEvent.Rating
                            });

            m_ReadModel.SaveChanges();
        }

        public void Handle(GameReviewDescriptionChangedEvent domainEvent)
        {
            GameReview movie = m_ReadModel.Find(domainEvent.AggregateRootId);
            movie.Description = domainEvent.Description;

            m_ReadModel.SaveChanges();
        }

        public void Handle(GameReviewRatingChangedEvent domainEvent)
        {
            GameReview movie = m_ReadModel.Find(domainEvent.AggregateRootId);
            movie.Rating = domainEvent.Rating;

            m_ReadModel.SaveChanges();
        }

        public void Handle(GameReviewTitleChangedEvent domainEvent)
        {
            GameReview movie = m_ReadModel.Find(domainEvent.AggregateRootId);
            movie.Title = domainEvent.Title;

            m_ReadModel.SaveChanges();
        }
    }
}