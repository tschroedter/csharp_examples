using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NUnit.Framework;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsSuitEqualTests
    {
        [SetUp]
        public void Setup() // todo use AutoFixture
        {
            m_Sut = new IsSuitEqual();
        }

        private IsSuitEqual m_Sut;

        [Test]
        public void IsSatisfied_Returns_False_For_Different_Suit()
        {
            // Arrange
            m_Sut.Actual = new TwoOfClubs();
            m_Sut.Threshold = new TwoOfHearts();

            // Act
            // Assert
            Assert.False(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Same_Card()
        {
            // Arrange
            m_Sut.Actual = new TwoOfClubs();
            m_Sut.Threshold = m_Sut.Actual;

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Same_Suit()
        {
            // Arrange
            m_Sut.Actual = new TwoOfClubs();
            m_Sut.Threshold = new TwoOfClubs();

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }
    }
}