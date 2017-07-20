using JetBrains.Annotations;
using SimpleCqrs.Commanding;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace ALS.CQRS.Contracts.Commands
{
    [UsedImplicitly]
    public class CreateGameReviewCommand
        : ICommand
    {
        public CreateGameReviewCommand(
            [NotNull] string title,
            [NotNull] string description,
            int rating)
        {
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