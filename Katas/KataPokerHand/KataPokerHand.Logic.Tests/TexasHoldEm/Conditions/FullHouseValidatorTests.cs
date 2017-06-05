using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class FullHouseValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new FullHouseValidator();
        }

        private FullHouseValidator m_Sut;

        private ICard[] CreateCardsWithFullHouse()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new KingOfSpades(),
                       new KingOfHearts()
                   };
        }

        private ICard[] CreateCardsWithNotFullHouse()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new TwoOfSpades(),
                       new KingOfHearts()
                   };
        }

        [Test]
        public void IsValid_Returns_False_For_Not_FullHouse()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithNotFullHouse();

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_FullHouse()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithFullHouse();

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Sets_ThreeOfAKind()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithFullHouse();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.ThreeOfAKind.ToArray();
            Assert.AreEqual(3,
                            actual.Length);
            Assert.True(actual [ 0 ] is TwoOfClubs);
            Assert.True(actual [ 1 ] is TwoOfDiamonds);
            Assert.True(actual [ 2 ] is TwoOfHearts);
        }

        [Test]
        public void IsValid_Sets_TwoOfAKind()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithFullHouse();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.TwoOfAKind.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ] is KingOfSpades);
            Assert.True(actual [ 1 ] is KingOfHearts);
        }
    }
}