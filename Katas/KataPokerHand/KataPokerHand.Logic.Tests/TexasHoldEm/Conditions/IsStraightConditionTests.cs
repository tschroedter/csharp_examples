using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsStraightConditionTests
    {
        [SetUp]
        public void SetUp()
        {
            m_Sut = new IsStraightCondition();
        }

        private IsStraightCondition m_Sut;

        [Test]
        public void IsSatisfied_Returns_False_For_Cards_Empty()
        {
            // Arrange
            // Act
            m_Sut.Cards = new ICard[0];

            // Assert
            Assert.False(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_False_For_Not_Straight()
        {
            // Arrange
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FiveOfClubs());

            // Act
            m_Sut.Cards = cards.ToArray();

            // Assert
            Assert.False(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_True_For__Straight()
        {
            // Arrange
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfClubs());

            // Act
            m_Sut.Cards = cards.ToArray();

            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }
    }
}