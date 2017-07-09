using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Repositories
{
    public interface IGamesReviewsRepository
        : IRepository <IGameReview>
    {
    }
}