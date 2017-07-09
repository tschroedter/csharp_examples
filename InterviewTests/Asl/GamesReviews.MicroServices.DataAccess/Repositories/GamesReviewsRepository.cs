using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Contexts;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Repositories
{
    [UsedImplicitly]
    public class GamesReviewsRepository
        : BaseRepository <IGameReview, IGamesReviewsContext>,
          IGamesReviewsRepository,
          ICommandGamesReviewsRepository,
          IQueryGamesReviewsRepository
    {
        public GamesReviewsRepository(
            [NotNull] IGamesReviewsContext context)
            : base(context)
        {
        }

        public IQueryable <IGameReview> FindByRating(int rating)
        {
            return Context.FindByRating(rating);
        }

        protected override IQueryable <IGameReview> GetAll()
        {
            return Context.GamesReviews();
        }
    }
}