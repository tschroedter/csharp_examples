using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace PlayingCards.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StringToCardFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            IEnumerable <ICard> cards = CreateCards();
            m_Sut = new StringToCardFactory();
            m_Sut.Initialize(cards);
        }

        private StringToCardFactory m_Sut;

        private IEnumerable <ICard> CreateCards()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new ThreeOfClubs(),
                       new FourOfClubs()
                   };
        }

        [Test]
        public void ToCard_Returns_Card_For_Known_String()
        {
            // Arrange

            // Act
            ICard actual = m_Sut.ToCard("Two of Clubs");

            // Assert
            Assert.True(actual is TwoOfClubs);
        }

        [Test]
        public void ToCard_Returns_Card_For_Known_String_Ignoring_Case()
        {
            // Arrange

            // Act
            ICard actual = m_Sut.ToCard("TWO of CLUBS");

            // Assert
            Assert.True(actual is TwoOfClubs);
        }

        [Test]
        public void ToCard_Returns_Unknown_Card_For_Unknown_String()
        {
            // Arrange

            // Act
            ICard actual = m_Sut.ToCard("???");

            // Assert
            Assert.True(actual is UnknownCard);
        }
    }
}