using ALS.CQRS.DataAccess.Interfaces;
using ALS.CQRS.DataAccess.ReadModels;

namespace ALS.CQRS.Application.EventHandlers
{
    public interface IGameReviesReadModel
        : IDbContext <GameReview>
    {
    }
}