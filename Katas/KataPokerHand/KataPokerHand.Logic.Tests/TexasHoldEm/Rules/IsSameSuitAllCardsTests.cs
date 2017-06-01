using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsSameSuitAllCardsTests
    {
        private IsSameSuitAllCards m_Sut;

        [SetUp]
        public void Setup()
        {
            m_Sut = new IsSameSuitAllCards();
        }

        [Test]
        public void IsSatisfied_Returns_True_For_All_Cards_Same_Suit()
        {
            // Arrange
            var cards = new List<ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfClubs());

            // Act
            m_Sut.Cards = cards.ToArray();

            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_False_For_Not_All_Cards_Same_Suit()
        {
            // Arrange
            var cards = new List<ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfHearts());

            // Act
            m_Sut.Cards = cards.ToArray();

            // Assert
            Assert.False(m_Sut.IsSatisfied());
        }
    }
}