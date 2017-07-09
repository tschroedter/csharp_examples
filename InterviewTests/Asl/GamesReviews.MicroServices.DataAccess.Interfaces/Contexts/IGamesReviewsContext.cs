using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Contexts
{
    public interface IGamesReviewsContext
        : IDbContext <IGameReview>
    {
        IQueryable <IGameReview> GamesReviews();
        IQueryable <IGameReview> FindByRating(int rating);
    }
}