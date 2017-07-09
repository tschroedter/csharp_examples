using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using GamesReviews.MicroServices.Nancy.Interfaces;
using JetBrains.Annotations;
using NUnit.Framework;

namespace GamesReviews.MicroServices.Nancy.Tests
{
    [ExcludeFromCodeCoverage]
    public static class GameReviewHelper
    {
        public static void AssertEntityAndResponse(
            [NotNull] IGameReview[] entities,
            [NotNull] IGameReviewModel[] models)
        {
            foreach ( IGameReview review in entities )
            {
                IGameReviewModel model = models.FirstOrDefault(x => x.Id == review.Id);

                if ( model == null )
                {
                    Assert.Fail("Can't find IGameReviewResponse with Id: " + review.Id);
                }

                AssertEntityAndResponse(review,
                                        model);
            }
        }

        public static void AssertEntityAndResponse(
            [NotNull] IGameReview review,
            [NotNull] IGameReviewModel model)
        {
            Assert.AreEqual(review.Id,
                            model.Id,
                            "Id");
            Assert.AreEqual(review.Title,
                            model.Title,
                            "Title");
            Assert.AreEqual(review.Description,
                            model.Description,
                            "Description");
            Assert.AreEqual(review.Rating,
                            model.Rating,
                            "Rating");
            Assert.AreEqual(new string('*',
                                       review.Rating),
                            model.RatingAsStars,
                            "RatingAsStars");
        }
    }
}