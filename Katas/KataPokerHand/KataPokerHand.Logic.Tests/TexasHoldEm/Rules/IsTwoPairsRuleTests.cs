using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using KataPokerHand.Logic.TexasHoldEm.Conditions.Validators;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
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
    internal class IsTwoPairsRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.Cards.Returns(m_Cards);

            var validator = new TwoPairsValidator();
            m_Sut = new IsTwoPairsRule(new IsTwoPairs(validator),
                                       validator);
        }

        private IsTwoPairsRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;

        private ICard[] CreateCardsWithTwoPairs()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new ThreeOfHearts(),
                       new ThreeOfSpades(),
                       new AceOfHearts()
                   };
        }

        private ICard[] CreateCardsWithNoTwoPairs()
        {
            return new ICard[]
                   {
                       new AceOfHearts(),
                       new TwoOfClubs(),
                       new FiveOfDiamonds(),
                       new SevenOfHearts(),
                       new KingOfSpades()
                   };
        }

        [Test]
        public void Apply_Updates_FirstPairOfCards()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithTwoPairs());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            ICard[] cards = actual.FirstPairOfCards.ToArray();
            Assert.AreEqual(2,
                            cards.Length);
            Assert.True(cards [ 0 ] is TwoOfClubs);
            Assert.True(cards [ 1 ] is TwoOfDiamonds);
        }

        [Test]
        public void Apply_Updates_SecondPairOfCards()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithTwoPairs());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            ICard[] cards = actual.SecondPairOfCards.ToArray();
            Assert.AreEqual(2,
                            cards.Length);
            Assert.True(cards [ 0 ] is ThreeOfHearts);
            Assert.True(cards [ 1 ] is ThreeOfSpades);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithTwoPairs());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.TwoPairs,
                            actual.Status);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.TwoPairs,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithTwoPairs());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());

            Assert.True(actual.First() is IIsTwoPairs);
        }

        [Test]
        public void IsValid_Returns_False_For_No_Two_Pairs()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithNoTwoPairs());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_Two_Pairs()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithTwoPairs());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }
    }
}