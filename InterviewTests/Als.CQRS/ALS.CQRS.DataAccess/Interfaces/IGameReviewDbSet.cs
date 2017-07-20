using ALS.CQRS.DataAccess.ReadModels;
using JetBrains.Annotations;

namespace ALS.CQRS.DataAccess.Interfaces
{
    [UsedImplicitly]
    public interface IGameReviewDbSet
        : IDbSet <GameReview>
    {
    }
}