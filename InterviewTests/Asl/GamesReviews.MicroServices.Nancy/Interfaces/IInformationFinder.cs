using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.Nancy.Interfaces
{
    public interface IInformationFinder
    {
        [CanBeNull]
        IGameReviewModel FindById(Guid id);

        IEnumerable <IGameReviewModel> List();
        void Delete(Guid id);
        void Save([NotNull] IGameReviewModel instance);
        IEnumerable <IGameReviewModel> FindByRating(int rating);
    }
}