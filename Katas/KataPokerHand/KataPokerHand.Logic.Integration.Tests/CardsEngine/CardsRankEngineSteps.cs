using System;
using System.Collections.Generic;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.CardsEngine
{
    [Binding]
    public class CardsRankEngineSteps
    {
        public CardsRankEngineSteps()
        {
            m_Cards = new List <ICard>();
            m_Info = new PlayerHandInformation
                     {
                         Cards = m_Cards
                     };
            m_StringToCard = new StringToCardFactory();
            m_StringToCard.Initialize(new CardsBuilder().Cards);

            m_Sut = new CardsRankEngine(new CardsRankRuleRepository(new CardsRankRulesBuilder().Rules));
        }

        private readonly List <ICard> m_Cards;
        private readonly PlayerHandInformation m_Info;
        private readonly IStringToCardFactory m_StringToCard;
        private readonly CardsRankEngine m_Sut;

        [Given(@"I added a card '(.*)' to player cards")]
        public void GivenIAddedACardToPlayerCards(string cardAsString)
        {
            m_Cards.Add(m_StringToCard.ToCard(cardAsString));
        }

        [Then(@"the status should be '(.*)'")]
        public void ThenTheStatusShouldBe(string statusAsString)
        {
            object expected = Enum.Parse(typeof( Status ),
                                         statusAsString.Replace(" ",
                                                                ""));

            Assert.AreEqual(expected,
                            m_Info.Status);
        }

        [When(@"I apply the rules")]
        public void WhenIApplyTheRules()
        {
            m_Sut.ApplyRules(new[]
                             {
                                 m_Info
                             });
        }
    }
}