using System;
using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using TechTalk.SpecFlow;
using static System.Console;

namespace KataPokerHand.Logic.Integration.Tests.CardsRankEngineTests
{
    [Binding]
    public class CardsRankEngineSteps
    {
        public CardsRankEngineSteps()
        {
            m_StringToCardRank = new StringToCardRankFactory();
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
        private readonly IPlayerHandInformation m_Info;
        private readonly IStringToCardFactory m_StringToCard;
        private readonly CardsRankEngine m_Sut;
        private readonly IStringToCardRankFactory m_StringToCardRank;

        [Given(@"I added a card '(.*)' to player cards")]
        public void GivenIAddedACardToPlayerCards(string cardAsString)
        {
            m_Cards.Add(m_StringToCard.ToCard(cardAsString));
        }

        [Then(@"the Rank should be '(.*)'")]
        public void ThenTheCardRankShouldBe(string cardRankAsString)
        {
            var expected = m_StringToCardRank.ToCardRank(cardRankAsString);

            Assert.AreEqual(expected,
                            m_Info.Rank);
        }

        [Then(@"the FourOfAKind should be '(.*)'")]
        public void ThenTheFourOfAKindShouldBe(string cardsAsString)
        {
            List <ICard> cards = ConvertCardsStringsToList(cardsAsString);

            foreach ( ICard card in cards )
            {
                WriteLine("'FourOfAKind' should contain expected card: {0}",
                          card);

                Assert.True(m_Info.FourOfAKind.Any(x => x.ToString() == card.ToString())); // todo need equals

                WriteLine("Found card: {0}",
                          card);
            }
        }

        [Then(@"the HighestCard should be '(.*)'")]
        public void ThenTheHighestCardShouldBe(string cardAsString)
        {
            ICard expected = m_StringToCard.ToCard(cardAsString);

            Assert.AreEqual(expected.ToString(),
                            m_Info.HighestCard.ToString()); // todo implement equals for Cards
        }

        [Then(@"the status should be '(.*)'")]
        public void ThenTheStatusShouldBe(string statusAsString)
        {
            var expected = ( Status ) Enum.Parse(typeof( Status ),
                                                 statusAsString);

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

        private List <ICard> ConvertCardsStringsToList(string cardsAsString)
        {
            var cards = new List <ICard>();

            string[] cardsAStringArray = cardsAsString.Split(',');

            foreach ( string cardAsString in cardsAStringArray )
            {
                cards.Add(m_StringToCard.ToCard(cardAsString.Trim()));
            }

            return cards;
        }
    }
}