using System;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Repositories
{
    public interface IQueryGamesReviewsRepository
    {
        [NotNull]
        IQueryable <IGameReview> All { get; }

        [CanBeNull]
        IGameReview FindById(Guid threeId);

        [NotNull]
        IQueryable <IGameReview> FindByRating(int rating);
    }
}