using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsFourCardsSameValueConditionTests
    {
        [SetUp]
        public void Setup()
        {
            m_Validator = Substitute.For <IFourCardsWithSameValueValidator>();
            m_Validator.IsValid().Returns(true);
            m_Sut = new IsFourCardsSameValueCondition(m_Validator);
        }

        private IsFourCardsSameValueCondition m_Sut;
        private IFourCardsWithSameValueValidator m_Validator;

        [Test]
        public void IsSatisfied_Calls_Validator()
        {
            // Arrange
            m_Validator.IsValid().Returns(true);

            // Act
            // Assert
            Assert.True(m_Sut.IsSatisfied());
        }


        [Test]
        public void IsSatisfied_Sets_Cards()
        {
            // Arrange
            var cards = new ICard[]
                        {
                            new TwoOfClubs()
                        };

            m_Validator.IsValid().Returns(true);

            m_Sut.Cards = cards;

            // Act
            m_Sut.IsSatisfied();

            // Assert
            Assert.AreEqual(cards,
                            m_Validator.Cards);
        }
    }
}