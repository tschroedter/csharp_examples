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
    internal class IsThreeOfAKindRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.Cards.Returns(m_Cards);

            var validator = new ThreeCardsWithSameValueValidator();
            m_Sut = new IsThreeOfAKindRule(new IsThreeOfAKindCondition(validator),
                                           validator);
        }

        private IsThreeOfAKindRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;

        private ICard[] CreateCardsWithThreeSameValue()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new JackOfSpades(),
                       new AceOfHearts()
                   };
        }

        private ICard[] CreateCardsWithFourDifferentValue()
        {
            return new ICard[]
                   {
                       new AceOfHearts(),
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new JackOfHearts(),
                       new KingOfSpades()
                   };
        }

        [Test]
        public void Apply_Updates_HighestCard()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual("AH",
                            actual.HighestCard.ToString());
        }

        [Test]
        public void Apply_Updates_HighestCards()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.True(actual.HighestCard is AceOfHearts);
        }

        [Test]
        public void Apply_Updates_OtherCards()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            ICard[] fourOfAKind = actual.OtherCards.ToArray();
            Assert.AreEqual(2,
                            fourOfAKind.Length);
            Assert.True(fourOfAKind [ 0 ] is JackOfSpades);
            Assert.True(fourOfAKind [ 1 ] is AceOfHearts);
        }

        [Test]
        public void Apply_Updates_Ranks()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(CardRank.Two,
                            actual.Rank);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.ThreeOfAKind,
                            actual.Status);
        }

        [Test]
        public void Apply_Updates_ThreeOfAKind()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            ICard[] fourOfAKind = actual.ThreeOfAKind.ToArray();
            Assert.AreEqual(3,
                            fourOfAKind.Length);
            Assert.True(fourOfAKind [ 0 ] is TwoOfClubs);
            Assert.True(fourOfAKind [ 1 ] is TwoOfDiamonds);
            Assert.True(fourOfAKind [ 2 ] is TwoOfHearts);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.ThreeOfAKind,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());

            Assert.True(actual.First() is IIsThreeOfAKindCondition);
        }

        [Test]
        public void IsValid_Returns_False_For_Different_Kind()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithFourDifferentValue());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.False(m_Sut.IsValid());
        }

        [Test]
        public void IsValid_Returns_True_For_All_Cards_Same_Kind()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithThreeSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }
    }
}