using System;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.DataAccess.Interfaces.Repositories
{
    public interface ICommandGamesReviewsRepository
    {
        void Save([NotNull] IGameReview instance);
        void RemoveById(Guid id);
    }
}