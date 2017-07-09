using JetBrains.Annotations;

namespace GamesReviews.MicroServices.Nancy.Interfaces
{
    public interface IGameReviewModel
        : IModel
    {
        [CanBeNull]
        string Title { get; set; }

        [CanBeNull]
        string Description { get; set; }

        int Rating { get; set; }

        [NotNull]
        string RatingAsStars { get; }
    }
}