using System;
using JetBrains.Annotations;
using SimpleCqrs.Eventing;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ALS.CQRS.Contracts.Events
{
    [UsedImplicitly]
    public class GameReviewDescriptionChangedEvent
        : DomainEvent
    {
        public GameReviewDescriptionChangedEvent(
            Guid movieId,
            [NotNull] string description)
        {
            AggregateRootId = movieId;
            Description = description;
        }

        [NotNull]
        public string Description { get; set; }
    }
}