using ALS.CQRS.DataAccess.Interfaces;
using ALS.CQRS.DataAccess.ReadModels;

namespace ALS.CQRS.Events.Handlers
{
    public interface IGameReviesReadModel
        : IDbContext <GameReview>
    {
    }
}