using System;
using JetBrains.Annotations;
using SimpleCqrs.Eventing;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ALS.CQRS.Events
{
    [UsedImplicitly]
    public class GameReviewCreatedEvent
        : DomainEvent
    {
        public GameReviewCreatedEvent(
            Guid movieId,
            [NotNull] string title,
            [NotNull] string description,
            int rating)
        {
            AggregateRootId = movieId;
            Title = title;
            Description = description;
            Rating = rating;
        }

        [NotNull]
        public string Title { get; set; }

        [NotNull]
        public string Description { get; set; }

        public int Rating { get; set; }
    }
}