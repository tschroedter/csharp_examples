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
    internal sealed class OnePairValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new OnePairValidator();
        }

        private OnePairValidator m_Sut;

        private ICard[] CreateCardsWithOnePair()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new ThreeOfHearts(),
                       new FourOfSpades(),
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
        public void IsSatisfied_Returns_False_For_No_Pair()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithNoPairs();

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_One_Pair()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithOnePair();

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsSatisfied_Sets_HighestCard()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithOnePair();

            // Act
            m_Sut.IsValid();

            // Assert
            Assert.True(m_Sut.HighestCard is AceOfHearts);
        }

        [Test]
        public void IsSatisfied_Sets_OtherCards()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithOnePair();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.OtherCards.ToArray();
            Assert.AreEqual(3,
                            actual.Length);
            Assert.True(actual [ 0 ] is ThreeOfHearts);
            Assert.True(actual [ 1 ] is FourOfSpades);
            Assert.True(actual [ 2 ] is AceOfHearts);
        }

        [Test]
        public void IsSatisfied_Sets_PairOfCards()
        {
            // Arrange
            m_Sut.Cards = CreateCardsWithOnePair();

            // Act
            m_Sut.IsValid();

            // Assert
            ICard[] actual = m_Sut.PairOfCards.ToArray();
            Assert.AreEqual(2,
                            actual.Length);
            Assert.True(actual [ 0 ] is TwoOfClubs);
            Assert.True(actual [ 1 ] is TwoOfDiamonds);
        }
    }
}