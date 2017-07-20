using System;
using JetBrains.Annotations;
using SimpleCqrs.Eventing;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ALS.CQRS.Events
{
    [UsedImplicitly]
    public class GameReviewRatingChangedEvent
        : DomainEvent
    {
        public GameReviewRatingChangedEvent(
            Guid movieId,
            int rating)
        {
            AggregateRootId = movieId;
            Rating = rating;
        }

        public int Rating { get; set; }
    }
}