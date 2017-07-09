using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GamesReviews.MicroServices.Nancy.Interfaces;
using Nancy;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace GamesReviews.MicroServices.Nancy.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class RequestHandlerTests
    {
        [SetUp]
        public void Setup()
        {
            m_ModelOne = new GameReviewModel
                         {
                             Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                             Title = "Title 1",
                             Description = "Description 1",
                             Rating = 1
                         };

            m_ModelTwo = new GameReviewModel
                         {
                             Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                             Title = "Title 2",
                             Description = "Description 2",
                             Rating = 2
                         };

            m_Responses = new[]
                          {
                              m_ModelOne,
                              m_ModelTwo
                          }.AsQueryable();

            var mocker = new NSubstituteAutoMocker <RequestHandler>();
            m_Finder = mocker.Get <IInformationFinder>();

            m_Sut = mocker.ClassUnderTest;
        }

        private IGameReviewModel m_ModelOne;
        private IGameReviewModel m_ModelTwo;
        private IQueryable <IGameReviewModel> m_Responses;
        private IInformationFinder m_Finder;
        private RequestHandler m_Sut;

        [Test]
        public void Delete_Returns_Calls_Finder()
        {
            // Arrange
            Guid id = Guid.Parse("10000000-0000-0000-0000-000000000000");

            // Act
            m_Sut.Delete(id);

            // Assert
            m_Finder.Received().Delete(id);
        }

        [Test]
        public void FindById_Returns_Response_For_Known()
        {
            // Arrange
            m_Finder.FindById(m_ModelOne.Id).Returns(m_ModelOne);

            // Act
            Response actual = m_Sut.FindById(m_ModelOne.Id);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK,
                            actual.StatusCode);
        }

        [Test]
        public void FindById_Returns_Response_For_Unknown()
        {
            // Arrange
            Guid doesNotMatter = Guid.NewGuid();

            m_Finder.FindById(Arg.Any <Guid>()).Returns(( IGameReviewModel ) null);

            // Act
            Response actual = m_Sut.FindById(doesNotMatter);

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound,
                            actual.StatusCode);
        }

        [Test]
        public void FindByRating_Calls_Finder()
        {
            // Arrange
            // Act
            m_Sut.FindByRating(1);

            // Assert
            m_Finder.Received().FindByRating(1);
        }

        [Test]
        public void FindByRating_Returns_Response_When_Called()
        {
            // Arrange
            const int doesNotMatter = -1;

            m_Finder.FindByRating(Arg.Any <int>()).Returns(new IGameReviewModel[0]);

            // Act
            Response actual = m_Sut.FindByRating(doesNotMatter);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK,
                            actual.StatusCode);
        }

        [Test]
        public void List_Returns_Response_When_Called()
        {
            // Arrange
            m_Finder.List().Returns(m_Responses);

            // Act
            Response actual = m_Sut.List();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK,
                            actual.StatusCode);
        }

        [Test]
        public void Save_Returns_Calls_Finder()
        {
            // Arrange
            // Act
            m_Sut.Save(m_ModelOne);

            // Assert
            m_Finder.Received().Save(m_ModelOne);
        }

        [Test]
        public void Save_Returns_Response_Known()
        {
            // Arrange
            // Act
            Response actual = m_Sut.Save(m_ModelOne);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK,
                            actual.StatusCode);
        }
    }
}