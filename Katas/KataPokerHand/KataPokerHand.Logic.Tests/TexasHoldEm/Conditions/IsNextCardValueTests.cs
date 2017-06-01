using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsNextCardValueTests
    {
        [SetUp]
        public void Setup() // todo use AutoFixture
        {
            m_CardOne = Substitute.For <ICard>();
            m_CardOne.Value.Returns('2');

            m_CardTwo = Substitute.For <ICard>();
            m_CardTwo.Value.Returns('3');

            m_Finder = Substitute.For <INextCardValueFinder>();
            m_Sut = new IsNextCardValue(m_Finder);
        }

        private IsNextCardValue m_Sut;
        private INextCardValueFinder m_Finder;
        private ICard m_CardOne;
        private ICard m_CardTwo;


        [Test]
        public void IsSatisfied_Returns_True_For_Next_Card_Is_Correct()
        {
            // Arrange
            m_Finder.NextCardValue(Arg.Any <char>()).Returns('3');

            m_Sut.CardOne = m_CardOne;
            m_Sut.CardTwo = m_CardTwo;

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }

        [Test]
        public void IsSatisfied_Returns_True_For_Next_Card_Is_Incorrect()
        {
            // Arrange
            m_Finder.NextCardValue(Arg.Any <char>()).Returns('0');

            m_Sut.CardOne = m_CardOne;
            m_Sut.CardTwo = m_CardTwo;

            // Act
            // Assert
            Assert.False(m_Sut.IsSatisfied());
        }
    }
}