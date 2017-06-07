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
using PlayingCards.Decks.Cards.Diamonds;
using PlayingCards.Decks.Cards.Hearts;
using PlayingCards.Decks.Cards.Spades;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.Tests.TexasHoldEm.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class IsHighCardRuleTests
    {
        [SetUp]
        public void Setup()
        {
            m_Cards = new List <ICard>();
            m_Info = Substitute.For <IPlayerHandInformation>();
            m_Info.Cards.Returns(m_Cards);

            m_Sut = new IsHighCardRule(new IsAlwaysTrue());
        }

        private IsHighCardRule m_Sut;
        private IPlayerHandInformation m_Info;
        private List <ICard> m_Cards;

        private ICard[] CreateCards()
        {
            return new ICard[]
                   {
                       new TwoOfClubs(),
                       new FiveOfDiamonds(),
                       new SevenOfHearts(),
                       new NineOfSpades(),
                       new AceOfHearts()
                   };
        }

        [Test]
        public void Apply_Updates_HighestCards()
        {
            // Arrange
            m_Cards.AddRange(CreateCards());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.True(actual.HighestCard is AceOfHearts);
        }

        [Test]
        public void Apply_Updates_Status()
        {
            // Arrange
            m_Cards.AddRange(CreateCards());
            m_Sut.Initialize(m_Info);

            // Act
            IPlayerHandInformation actual = m_Sut.Apply(m_Info);

            // Assert
            Assert.AreEqual(Status.HighCard,
                            actual.Status);
        }

        [Test]
        public void GetPriority_Returns_Value()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(( int ) RulesPriority.HighCard,
                            m_Sut.GetPriority());
        }

        [Test]
        public void Initialize_Adds_Conditions()
        {
            // Arrange
            m_Cards.AddRange(CreateCards());

            // Act
            m_Sut.Initialize(m_Info);

            // Assert
            IEnumerable <ICondition> actual = m_Sut.GetConditions();
            Assert.AreEqual(1,
                            actual.Count());

            Assert.True(actual.First() is IIsAlwaysTrue);
        }
    }
}