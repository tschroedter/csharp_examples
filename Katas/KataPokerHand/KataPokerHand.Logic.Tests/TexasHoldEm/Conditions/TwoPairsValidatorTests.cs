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
    internal sealed class TwoPairsValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new TwoPairsValidator();
        }

        private TwoPairsValidator m_Sut;

        private ICard[] CreateCardsWithTwoPairs()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new ThreeOfHearts(),
                       new ThreeOfSpades(),
                       new AceOfHearts()
                   };
        }

        private ICard[] CreateCardsWithNoPairs()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new ThreeOfDiamonds(),
                       new NineOfHearts(),
                       new JackOfSpades(),
                       new AceOfHearts()
                   };
        }

        [Test]
        public void IsSatisfied_Returns_False_For_No_Two_Pairs()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithNoPairs();

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Two_Pairs()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithTwoPairs();

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsSatisfied_Sets_FirstPairOfCards()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithTwoPairs();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.FirstPairOfCards.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ] is TwoOfClubs);
            Assert.True(actual [ 1 ] is TwoOfDiamonds);
        }

        [Test]
        public void IsSatisfied_Sets_SecondPairOfCards()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithTwoPairs();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.SecondPairOfCards.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ] is ThreeOfHearts);
            Assert.True(actual [ 1 ] is ThreeOfSpades);
        }
    }
}