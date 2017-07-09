using System;
using System.Collections.Generic;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Repositories;
using GamesReviews.MicroServices.Nancy.Interfaces;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.Nancy
{
    [UsedImplicitly]
    public class InformationFinder
        : IInformationFinder
    {
        private readonly ICommandGamesReviewsRepository m_Command;
        private readonly IQueryGamesReviewsRepository m_Query;

        public InformationFinder(
            [NotNull] ICommandGamesReviewsRepository command,
            [NotNull] IQueryGamesReviewsRepository query)
        {
            m_Command = command;
            m_Query = query;
        }

        public IGameReviewModel FindById(Guid id)
        {
            IGameReview review = m_Query.FindById(id);

            return review == null
                       ? null
                       : new GameReviewModel(review);
        }

        public IEnumerable <IGameReviewModel> List()
        {
            IEnumerable <IGameReview> reviews = m_Query.All;

            GameReviewModel[] models = reviews.Select(review => new GameReviewModel(review))
                                              .ToArray();

            return models;
        }

        public void Delete(Guid id)
        {
            m_Command.RemoveById(id);
        }

        public void Save(IGameReviewModel instance)
        {
            IGameReview toBeUpdated = ToGameReview(instance);

            m_Command.Save(toBeUpdated);
        }

        public IEnumerable <IGameReviewModel> FindByRating(int rating)
        {
            IQueryable <IGameReview> reviews = m_Query.FindByRating(rating);

            GameReviewModel[] models = reviews.Select(review => new GameReviewModel(review))
                                              .ToArray();

            return models;
        }

        private IGameReview ToGameReview(IGameReviewModel model)
        {
            IGameReview instance = new GameReview
                                   {
                                       Id = model.Id,
                                       Title = model.Title,
                                       Description = model.Description,
                                       Rating = model.Rating
                                   };

            return instance;
        }
    }
}