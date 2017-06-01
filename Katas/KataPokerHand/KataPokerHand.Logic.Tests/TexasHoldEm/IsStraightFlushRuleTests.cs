using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Cards.Clubs;
using PlayingCards.Decks.Cards.Hearts;

namespace KataPokerHand.Logic.Tests.TexasHoldEm
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsStraightFlushRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Hand = Substitute.For <IPlayerHand>();
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.PlayerHand.Returns(m_Hand);
            m_Hand.Cards.Returns(m_Cards);

            m_Sut = new IsStraightFlushRule();
        }

        private IsStraightFlushRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;
        private IPlayerHand m_Hand;

        private IEnumerable <ICard> CreateStraightFlush()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfClubs());
            cards.Add(new FiveOfClubs());
            cards.Add(new SixOfClubs());

            return cards;
        }

        private IEnumerable <ICard> CreateCardsWithDifferentSuits()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfClubs());
            cards.Add(new FiveOfClubs());
            cards.Add(new SixOfHearts());

            return cards;
        }

        private IEnumerable <ICard> CreateCardsNotAStraightFlush()
        {
            var cards = new List <ICard>();

            cards.Add(new TwoOfClubs());
            cards.Add(new ThreeOfClubs());
            cards.Add(new FourOfClubs());
            cards.Add(new FiveOfClubs());
            cards.Add(new SevenOfHearts());

            return cards;
        }

        [Test]
        public void Apply_Updates_HighestCard()
        {
            // Arrange
            m_Cards.AddRange(CreateStraightFlush());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(6u,
                            actual.HighestCard); // todo enum for suits
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Cards.AddRange(CreateStraightFlush());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.StraightFlush,
                            actual.Status);
        }

        [Test]
        public void Apply_Updates_Suit()
        {
            // Arrange
            m_Cards.AddRange(CreateStraightFlush());

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual('C',
                            actual.Suit); // todo enum for suits
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(2,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Condition_For_Cards_Empty()
        {
            // Arrange
            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            Assert.AreEqual(1,
                            m_Sut.GetConditions().Count()); // todo maybe there is a better test
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateStraightFlush());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            Assert.AreEqual(3,
                            m_Sut.GetConditions().Count()); // todo maybe there is a better test
        }

        [Test]
        public void IsValid_Returns_False_For_Different_Suits()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithDifferentSuits());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_All_Cards_Same_Suit()
        {
            // Arrange
            m_Cards.AddRange(CreateStraightFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_Not_A_StraightFlush()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsNotAStraightFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_StraightFlush()
        {
            // Arrange
            m_Cards.AddRange(CreateStraightFlush());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }
    }
}