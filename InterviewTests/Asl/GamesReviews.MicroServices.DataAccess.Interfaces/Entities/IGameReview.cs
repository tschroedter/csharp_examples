using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Entities
{
    public interface IGameReview
        : IEntity
    {
        [CanBeNull]
        string Title { get; set; }

        [CanBeNull]
        string Description { get; set; }

        int Rating { get; set; }
    }
}