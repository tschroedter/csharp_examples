using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards;
using PlayingCards.Decks.Suits;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsNumberOfCardsIncorrectRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Invalid = Substitute.For <IIsNumberOfCardsInvalid>();
            m_Sut = new IsNumberOfCardsIncorrectRule(m_Invalid);
        }

        private IPlayerHandInformation m_Info;
        private IsNumberOfCardsIncorrectRule m_Sut;
        private IIsNumberOfCardsInvalid m_Invalid;

        [Test]
        public void Apply_Updates_HighestCard()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(UnknownCard.Unknown,
                            actual.HighestCard);
        }

        [Test]
        public void Apply_Updates_Rank()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(CardRank.Unknown,
                            actual.Rank);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.NumberOfCardsIncorrect,
                            actual.Status);
        }

        [Test]
        public void Apply_Updates_Suit()
        {
            // Arrange
            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(UnknownSuit.Unknown,
                            actual.Suit);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.NumberOfCardsIncorrect,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());
            Assert.True(actual.First() is IIsNumberOfCardsInvalid);
        }
    }
}