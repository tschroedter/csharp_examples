using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsStraightTests
    {
        [Test]
        public void IsSatisfied_Returns_True_For__Straight()
        {
            // Arrange
            var cards = new List<ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfClubs());

            var sut = new IsStraight(cards.ToArray());

            // Act
            // Assert
            Assert.True(sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_False_For_Not_Straight()
        {
            // Arrange
            var cards = new List<ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FiveOfClubs());

            var sut = new IsStraight(cards.ToArray());

            // Act
            // Assert
            Assert.False(sut.IsSatisfied());
        }
    }
}