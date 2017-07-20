using ALS.CQRS.DataAccess.Interfaces;
using ALS.CQRS.DataAccess.ReadModels;
using JetBrains.Annotations;

namespace ALS.CQRS.Application.EventHandlers
{
    [UsedImplicitly]
    public class GameReviesReadModel
        : BaseReadModel <GameReview>,
          IGameReviesReadModel
    {
        public GameReviesReadModel(
            [NotNull] IDbSet <GameReview> dbSet)
            : base(dbSet)
        {
        }
    }
}