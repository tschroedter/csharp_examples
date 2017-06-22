using System.Collections.Generic;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Rules;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.CardsRankEngineTests
{
    [Binding]
    public class CardsRankEngineSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            var stringToCardRank = new StringToCardRankFactory();
            var stringToCard = new StringToCardFactory();
            stringToCard.Initialize(new CardsBuilder().Cards);

            var cards = new List <ICard>();
            var info = new PlayerHandInformation
                       {
                           Cards = cards
                       };

            var sut = new CardsRankEngine(new CardsRankRulesRepository(new CardsRankRulesBuilder().Rules));

            ScenarioContext.Current [ "ICards" ] = cards;
            ScenarioContext.Current [ "IPlayerHandInformation" ] = info;
            ScenarioContext.Current [ "ICardsRankEngine" ] = sut;
            ScenarioContext.Current [ "IStringToCardRankFactory" ] = stringToCardRank;
            ScenarioContext.Current [ "IStringToCardFactory" ] = stringToCard;
        }
    }
}