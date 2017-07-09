using System;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using GamesReviews.MicroServices.Nancy.Interfaces;
using JetBrains.Annotations;

namespace GamesReviews.MicroServices.Nancy
{
    public class GameReviewModel
        : Model,
          IGameReviewModel
    {
        public GameReviewModel()
        {
            Id = Guid.Empty;
            Title = "Unknown";
            Description = "Unknown";
            Rating = 0;
            RatingAsStars = "?";
        }

        public GameReviewModel(
            [NotNull] IGameReview review)
        {
            Id = review.Id;
            Title = review.Title;
            Description = review.Description;
            Rating = review.Rating;
            RatingAsStars = new string('*',
                                       review.Rating);
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string RatingAsStars { get; set; }
    }
}