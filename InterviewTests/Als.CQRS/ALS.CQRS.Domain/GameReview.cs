using System;
using System.Diagnostics.CodeAnalysis;
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
            Guid reviewId,
            [NotNull] string title,
            [NotNull] string description,
            int rating)
        {
            Id = reviewId;
            Title = title;
            Description = description;
            Rating = rating;
            //todo Implementation done in Step 6
        }

        [NotNull]
        public string Title { get; set; }

        [NotNull]
        public string Description { get; set; }

        public int Rating { get; set; }
    }
}