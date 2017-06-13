using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.TexasHoldEm.Conditions.Validators;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions.Validators
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ThreeCardsWithSameValueValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new ThreeCardsWithSameValueValidator();
        }

        private ThreeCardsWithSameValueValidator m_Sut;

        private ICard[] CreateCardsWithThreeSameValue()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new JackOfSpades(),
                       new AceOfHearts()
                   };
        }

        private ICard[] CreateCardsWithNotThreeSameValue()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new NineOfHearts(),
                       new JackOfSpades(),
                       new AceOfHearts()
                   };
        }

        [Test]
        public void IsValid_Returns_False_For_Not_Three_Cards_Same_Value()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithNotThreeSameValue();

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_Three_Cards_Same_Value()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithThreeSameValue();

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Sets_HighestCard()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithThreeSameValue();

            // Act
            m_Sut.IsValid();

            // Assert
            Assert.True(m_Sut.HighestCard is AceOfHearts);
        }

        [Test]
        public void IsValid_Sets_OtherCards()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithThreeSameValue();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.OtherCards.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ] is JackOfSpades);
            Assert.True(actual [ 1 ] is AceOfHearts);
        }

        [Test]
        public void IsValid_Sets_Rank()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithThreeSameValue();

            // Act
            m_Sut.IsValid();

            // Assert
            Assert.AreEqual(CardRank.Two,
                            m_Sut.Rank);
        }

        [Test]
        public void IsValid_Sets_ThreeOfAKind()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithThreeSameValue();

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
    }
}