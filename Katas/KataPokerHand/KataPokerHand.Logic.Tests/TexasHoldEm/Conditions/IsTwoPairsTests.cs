using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Conditions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class IsTwoPairsTests
    {
        [SetUp]
        public void Setup()
        {
            m_AutoMocker = new NSubstituteAutoMocker <IsTwoPairs>();
            m_Sut = m_AutoMocker.ClassUnderTest;
        }

        private NSubstituteAutoMocker <IsTwoPairs> m_AutoMocker;
        private IsTwoPairs m_Sut;

        [Test]
        public void IsSatisfied_Calls_Validator()
        {
            // Arrange
            m_AutoMocker.Get <ITwoPairsValidator>().IsValid().Returns(true);

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

            var validator = m_AutoMocker.Get <ITwoPairsValidator>();
            validator.IsValid().Returns(true);

            m_Sut.Cards = cards;

            // Act
            m_Sut.IsSatisfied();

            // Assert
            Assert.AreEqual(cards,
                            validator.Cards);
        }
    }
}