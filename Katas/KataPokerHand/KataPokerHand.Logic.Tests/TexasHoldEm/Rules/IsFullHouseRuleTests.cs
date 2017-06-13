using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsFullHouseRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Condition = Substitute.For <IIsFullHouseCondition>();
            m_Validator = Substitute.For <IFullHouseValidator>();
            m_Sut = new IsFullHouseRule(m_Condition,
                                        m_Validator);
        }

        private IPlayerHandInformation m_Info;
        private IsFullHouseRule m_Sut;
        private IIsFullHouseCondition m_Condition;
        private IFullHouseValidator m_Validator;

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Validator.IsValid().Returns(true);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.FullHouse,
                            actual.Status);
        }

        [Test]
        public void Apply_Updates_ThreeOfAKindd()
        {
            // Arrange

            var cards = new ICard[]
                        {
                            new TwoOfClubs(),
                            new TwoOfHearts(),
                            new TwoOfDiamonds()
                        };
            m_Validator.IsValid().Returns(true);
            m_Validator.ThreeOfAKind = cards;

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(cards,
                            actual.ThreeOfAKind);
        }

        [Test]
        public void Apply_Updates_TwoOfAKind()
        {
            // Arrange
            var cards = new ICard[]
                        {
                            new TwoOfClubs(),
                            new TwoOfHearts()
                        };
            m_Validator.IsValid().Returns(true);
            m_Validator.TwoOfAKind = cards;

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(cards,
                            actual.TwoOfAKind);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.FullHouse,
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
            Assert.True(actual.First() is IIsFullHouseCondition);
        }
    }
}