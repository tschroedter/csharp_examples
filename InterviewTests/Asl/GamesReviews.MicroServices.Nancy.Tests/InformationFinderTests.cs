using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GamesReviews.MicroServices.DataAccess.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Entities;
using GamesReviews.MicroServices.DataAccess.Interfaces.Repositories;
using GamesReviews.MicroServices.Nancy.Interfaces;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace GamesReviews.MicroServices.Nancy.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class InformationFinderTests
    {
        [SetUp]
        public void Setup()
        {
            m_EntityOne = new GameReview
                          {
                              Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                              Title = "Title 1",
                              Description = "Description 1",
                              Rating = 1
                          };

            m_EntityTwo = new GameReview
                          {
                              Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                              Title = "Title 2",
                              Description = "Description 2",
                              Rating = 2
                          };

            m_Entities = new[]
                         {
                             m_EntityOne,
                             m_EntityTwo
                         }.AsQueryable();

            var mocker = new NSubstituteAutoMocker <InformationFinder>();

            m_Command = mocker.Get <ICommandGamesReviewsRepository>();
            m_Query = mocker.Get <IQueryGamesReviewsRepository>();

            m_Sut = mocker.ClassUnderTest;
        }

        private InformationFinder m_Sut;
        private ICommandGamesReviewsRepository m_Command;
        private IQueryGamesReviewsRepository m_Query;
        private IGameReview m_EntityOne;
        private IGameReview m_EntityTwo;
        private IQueryable <IGameReview> m_Entities;

        [Test]
        public void Delete_Calls_Command()
        {
            // Arrange
            // Act
            m_Sut.Delete(m_EntityOne.Id);

            // Assert
            m_Command.Received().RemoveById(m_EntityOne.Id);
        }

        [Test]
        public void FindById_Returns_Response_For_Known_Id()
        {
            // Arrange
            m_Query.FindById(m_EntityOne.Id).Returns(m_EntityOne);

            // Act
            IGameReviewModel actual = m_Sut.FindById(m_EntityOne.Id);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(m_EntityOne.Id,
                            actual.Id);
        }

        [Test]
        public void FindById_Returns_Response_For_Unknown_Id()
        {
            // Arrange
            m_Query.FindById(Arg.Any <Guid>()).Returns(( IGameReview ) null);
            var unknownId = new Guid();

            // Act
            IGameReviewModel actual = m_Sut.FindById(unknownId);

            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void FindByRating_Returns_Responses()
        {
            // Arrange
            IQueryable <IGameReview> gameReviews = new[]
                                                   {
                                                       m_EntityOne
                                                   }.AsQueryable();

            m_Query.FindByRating(m_EntityOne.Rating).Returns(gameReviews);

            // Act
            IEnumerable <IGameReviewModel> actual = m_Sut.FindByRating(m_EntityOne.Rating);

            // Assert
            GameReviewHelper.
                AssertEntityAndResponse(m_EntityOne,
                                        actual.First());
        }

        [Test]
        public void List_Returns_Responses()
        {
            // Arrange
            m_Query.All.Returns(m_Entities);

            // Act
            IEnumerable <IGameReviewModel> actual = m_Sut.List();

            // Assert
            GameReviewHelper.
                AssertEntityAndResponse(m_Entities.ToArray(),
                                        actual.ToArray());
        }

        [Test]
        public void Save_Calls_Command()
        {
            // Arrange
            var response = new GameReviewModel(m_EntityOne);

            // Act
            m_Sut.Save(response);

            // Assert
            m_Command.Received().Save(Arg.Is <IGameReview>(x => ( x.Id == m_EntityOne.Id ) &&
                                                                ( x.Title == m_EntityOne.Title ) &&
                                                                ( x.Description == m_EntityOne.Description ) &&
                                                                ( x.Rating == m_EntityOne.Rating )));
        }
    }
}