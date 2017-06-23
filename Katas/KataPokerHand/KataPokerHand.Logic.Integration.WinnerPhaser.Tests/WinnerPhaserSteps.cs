using System.Collections.Generic;
using KataPokerHand.Logic.TexasHoldEm;
using KataPokerHand.Logic.TexasHoldEm.Ranking;
using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests
{
    [Binding]
    public class WinnerPhaserSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            var cards = new Dictionary <string, IEnumerable <ICard>>();

            var stringToCard = new StringToCardFactory();
            stringToCard.Initialize(new CardsBuilder().Cards);

            var engine = new CardsRankEngine(new CardsRankRulesRepository(new CardsRankRulesBuilder().Rules));
            var ranking = new CardsRanking(new PlayerInformationGroupedByStatus(),
                                           new SameStatusRankingContainer(new SameStatusRankingBuilder().Rankings));
            var phaser =
                new TexasHoldEm.WinnerPhaser(engine,
                                             ranking);

            ScenarioContext.Current [ "Cards" ] = cards;
            ScenarioContext.Current [ "StringToCardFactory" ] = stringToCard;
            ScenarioContext.Current [ "WinnerPhaser" ] = phaser;
        }
    }
}