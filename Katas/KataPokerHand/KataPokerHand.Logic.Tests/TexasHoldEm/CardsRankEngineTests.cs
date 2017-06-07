using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Conditions;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NSubstitute;
using NUnit.Framework;
using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Interfaces.Rules;

namespace KataPokerHand.Logic.Tests.TexasHoldEm
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class CardsRankEngineTests
    {
        // todo SpecFlow test using all rules
        [SetUp]
        public void Setup()
        {
            m_Info = new PlayerHandInformation();
            IEnumerable <IRule <IPlayerHandInformation>> rules = CreateRules();
            m_Repository = new CardsRankRuleRepository(rules);
            m_Sut = new CardsRankEngine(m_Repository);
        }

        private ICardsRankRuleRepository m_Repository;
        private CardsRankEngine m_Sut;
        private IPlayerHandInformation m_Info;

        private static IEnumerable <IRule <IPlayerHandInformation>> CreateRules()
        {
            var rules = new List <IRule <IPlayerHandInformation>>();

            rules.Add(new IsNumberOfCardsIncorrectRule(new IsNumberOfCardsInvalid()));
            rules.Add(new IsHighCardRule(new IsAlwaysTrue()));

            return rules;
        }

        [TestCase(0,
            Status.NumberOfCardsIncorrect)]
        [TestCase(1,
            Status.NumberOfCardsIncorrect)]
        [TestCase(2,
            Status.NumberOfCardsIncorrect)]
        [TestCase(3,
            Status.NumberOfCardsIncorrect)]
        [TestCase(4,
            Status.NumberOfCardsIncorrect)]
        [TestCase(5,
            Status.HighCard)]
        [TestCase(6,
            Status.NumberOfCardsIncorrect)]
        public void ApplyRules_Updates_Status_For_Cards(
            int numberOfCards,
            Status expected)
        {
            // Arrange
            var cards = new List <ICard>();

            for ( var i = 0 ; i < numberOfCards ; i++ )
            {
                cards.Add(Substitute.For <ICard>());
            }

            m_Info.Cards = cards;

            // Act
            m_Sut.ApplyRules(new[]
                             {
                                 m_Info
                             });

            // Assert
            Assert.AreEqual(expected,
                            m_Info.Status);
        }

        [Test]
        public void ApplyRules_Updates_Status_For_Cards_Empty()
        {
            // Arrange
            // Act
            m_Sut.ApplyRules(new[]
                             {
                                 m_Info
                             });

            // Assert
            Assert.AreEqual(Status.NumberOfCardsIncorrect,
                            m_Info.Status);
        }
    }
}