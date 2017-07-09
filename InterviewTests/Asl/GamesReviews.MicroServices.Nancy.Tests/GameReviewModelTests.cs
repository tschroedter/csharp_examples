using System;
using System.Diagnostics.CodeAnalysis;
using GamesReviews.MicroServices.DataAccess.Entities;
using NUnit.Framework;

namespace GamesReviews.MicroServices.Nancy.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class GameReviewModelTests
    {
        [Test]
        public void Constructor_Creates_Default_Instance()
        {
            // Arrange
            // Act
            var sut = new GameReviewModel();

            // Assert
            Assert.AreEqual(Guid.Empty,
                            sut.Id,
                            "Id");
            Assert.AreEqual("Unknown",
                            sut.Title,
                            "Title");
            Assert.AreEqual("Unknown",
                            sut.Description,
                            "Description");
            Assert.AreEqual(0,
                            sut.Rating,
                            "Rating");
            Assert.AreEqual("?",
                            sut.RatingAsStars,
                            "RatingAsStars");
        }

        [Test]
        public void Constructor_Creates_Instance()
        {
            // Arrange
            var review = new GameReview
                         {
                             Id = Guid.NewGuid(),
                             Title = "Title",
                             Description = "Description",
                             Rating = 1
                         };

            // Act
            var sut = new GameReviewModel(review);

            // Assert
            GameReviewHelper.AssertEntityAndResponse(review,
                                                     sut);
        }
    }
}