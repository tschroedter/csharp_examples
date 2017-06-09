using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsSuitEqualConditionTests
    {
        [SetUp]
        public void Setup() // todo use AutoFixture
        {
            m_Sut = new IsSuitEqualCondition();
        }

        private IsSuitEqualCondition m_Sut;

        [Test]
        public void IsSatisfied_Returns_False_For_Different_Suit()
        {
            // Arrange
            m_Sut.CardOne = new TwoOfClubs();
            m_Sut.CardTwo = new TwoOfHearts();

            // Act
            // Assert
            Assert.False(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Same_Card()
        {
            // Arrange
            m_Sut.CardOne = new TwoOfClubs();
            m_Sut.CardTwo = m_Sut.CardOne;

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Same_Suit()
        {
            // Arrange
            m_Sut.CardOne = new TwoOfClubs();
            m_Sut.CardTwo = new TwoOfClubs();

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }
    }
}