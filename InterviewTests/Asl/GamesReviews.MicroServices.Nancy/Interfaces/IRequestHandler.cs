using System;
using JetBrains.Annotations;
using Nancy;

namespace GamesReviews.MicroServices.Nancy.Interfaces
{
    public interface IRequestHandler
    {
        Response List();
        Response FindById(Guid id);
        Response Save([NotNull] IGameReviewModel instance);
        Response Delete(Guid id);
        Response FindByRating(int rating);
    }
}