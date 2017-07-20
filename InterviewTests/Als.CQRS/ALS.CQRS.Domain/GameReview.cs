using System;
using System.Diagnostics.CodeAnalysis;
using ALS.CQRS.Events;
using JetBrains.Annotations;
using SimpleCqrs.Domain;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ALS.CQRS.Domain
{
    [ExcludeFromCodeCoverage]
    public class GameReview
        : AggregateRoot
    {
        public GameReview(
            [NotNull] string title,
            [NotNull] string description,
            int rating)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Rating = rating;

            Apply(new GameReviewCreatedEvent(Id,
                                             title,
                                             description,
                                             rating));
        }

        [NotNull]
        public string Title { get; set; }

        [NotNull]
        public string Description { get; set; }

        public int Rating { get; set; }
    }
}