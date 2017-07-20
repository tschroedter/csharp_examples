using System;
using JetBrains.Annotations;
using SimpleCqrs.Eventing;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ALS.CQRS.Contracts.Events
{
    [UsedImplicitly]
    public class GameReviewTitleChangedEvent
        : DomainEvent
    {
        public GameReviewTitleChangedEvent(
            Guid movieId,
            [NotNull] string title)
        {
            AggregateRootId = movieId;
            Title = title;
        }

        [NotNull]
        public string Title { get; set; }
    }
}