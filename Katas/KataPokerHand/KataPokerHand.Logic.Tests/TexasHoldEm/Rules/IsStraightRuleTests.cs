using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsStraightRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Hand = Substitute.For <IPlayerHand>();
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.PlayerHand.Returns(m_Hand);
            m_Hand.Cards.Returns(m_Cards);

            m_Sut = new IsStraightRule(new IsStraight());
        }

        private IsStraightRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;
        private IPlayerHand m_Hand;

        private IEnumerable <ICard> CreateStraight()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfHearts());
            cards.Add(new FourOfDiamonds());
            cards.Add(new FiveOfSpades());
            cards.Add(new SixOfClubs());

            return cards;
        }

        private IEnumerable <ICard> CreateNoStraight()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfHearts());
            cards.Add(new FourOfDiamonds());
            cards.Add(new FiveOfSpades());
            cards.Add(new SevenOfClubs());

            return cards;
        }

        [Test]
        public void Apply_Updates_HighestCard()
        {
            // Arrange
            m_Cards.AddRange(CreateStraight());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.True(actual.HighestCard is SixOfClubs);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Cards.AddRange(CreateStraight());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.Straight,
                            actual.Status);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.Straight,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateStraight());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());
            Assert.True(actual.ElementAt(0) is IIsStraight);
        }

        [Test]
        public void IsValid_Returns_False_For_NoFlush()
        {
            // Arrange
            m_Cards.AddRange(CreateNoStraight());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_StraightFlush()
        {
            // Arrange
            m_Cards.AddRange(CreateStraight());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }
    }
}