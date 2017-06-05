using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    internal class IsFourOfAKindTests
    {
        [SetUp]
        public void Setup()
        {
            m_Hand = Substitute.For <IPlayerHand>();
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.PlayerHand.Returns(m_Hand);
            m_Hand.Cards.Returns(m_Cards);

            var validator = new FourCardsWithSameValueValidator();
            m_Sut = new IsFourOfAKindRule(new IsFourCardsSameValue(validator),
                                          validator);
        }

        private IsFourOfAKindRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;
        private IPlayerHand m_Hand;

        private ICard[] CreateCardsWithFourSameValue()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new TwoOfDiamonds(),
                       new TwoOfHearts(),
                       new TwoOfSpades(),
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
                       new TwoOfHearts(),
                       new KingOfSpades()
                   };
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.FourOfAKind,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateCardsWithFourSameValue());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());

            Assert.True(actual.First() is IIsFourCardsSameValue);
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
            m_Cards.AddRange(CreateCardsWithFourSameValue());
            m_Sut.Initialize(m_Info);

            // Act
            // Assert
            Assert.True(m_Sut.IsValid());
        }
    }
}