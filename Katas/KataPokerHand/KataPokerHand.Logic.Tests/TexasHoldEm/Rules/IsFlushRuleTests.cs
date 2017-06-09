using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;
using PlayingCards.Decks.Suits;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsFlushRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.Cards.Returns(m_Cards);

            m_Sut = new IsFlushRule(new IsSameSuitAllConditionCards());
        }

        private IsFlushRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;

        private IEnumerable <ICard> CreateFlush()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new FourOfClubs());
            cards.Add(new SixOfClubs());
            cards.Add(new EightOfClubs());
            cards.Add(new JackOfClubs());

            return cards;
        }

        private IEnumerable <ICard> CreateNoFlush()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new FourOfHearts());
            cards.Add(new SixOfClubs());
            cards.Add(new EightOfSpades());
            cards.Add(new JackOfClubs());

            return cards;
        }

        [Test]
        public void Apply_Updates_HighestCard()
        {
            // Arrange
            m_Cards.AddRange(CreateFlush());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.True(actual.HighestCard is JackOfClubs);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Cards.AddRange(CreateFlush());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.Flush,
                            actual.Status);
        }

        [Test]
        public void Apply_Updates_Suit()
        {
            // Arrange
            m_Cards.AddRange(CreateFlush());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.True(actual.Suit is Clubs);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.Flush,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateFlush());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());
            Assert.True(actual.ElementAt(0) is IIsSameSuitAllConditionCards);
        }

        [Test]
        public void IsValid_Returns_False_For_NoFlush()
        {
            // Arrange
            m_Cards.AddRange(CreateNoFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_False_For_Not_A_Flush()
        {
            // Arrange
            m_Cards.AddRange(CreateNoFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_All_Cards_Same_Suit()
        {
            // Arrange
            m_Cards.AddRange(CreateFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_StraightFlush()
        {
            // Arrange
            m_Cards.AddRange(CreateFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }
    }
}