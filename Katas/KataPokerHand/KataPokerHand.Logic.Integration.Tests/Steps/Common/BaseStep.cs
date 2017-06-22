using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.Interfaces.TexasHoldEm;
using KataPokerHand.Logic.Interfaces.TexasHoldEm.Rules;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;
using static System.Console;

namespace KataPokerHand.Logic.Integration.Tests.Steps.Common
{
    [Binding]
    public abstract class BaseStep
    {
        protected BaseStep()
        {
            Cards = ( List <ICard> ) ScenarioContext.Current [ "ICards" ];
            StringToCardRank = ( IStringToCardRankFactory ) ScenarioContext.Current [ "IStringToCardRankFactory" ];
            StringToCard = ( IStringToCardFactory ) ScenarioContext.Current [ "IStringToCardFactory" ];
            Info = ( IPlayerHandInformation ) ScenarioContext.Current [ "IPlayerHandInformation" ];
            Sut = ( ICardsRankEngine ) ScenarioContext.Current [ "ICardsRankEngine" ];
        }

        protected List <ICard> Cards { get; }
        protected IStringToCardRankFactory StringToCardRank { get; }
        protected IStringToCardFactory StringToCard { get; }
        protected ICardsRankEngine Sut { get; }
        protected IPlayerHandInformation Info { get; }

        protected void AssertCards(
            [NotNull] IEnumerable <ICard> expected,
            [NotNull] IEnumerable <ICard> actual,
            [NotNull] string description)
        {
            IEnumerable <ICard> array = expected as ICard[] ?? expected.ToArray();

            foreach ( ICard card in actual )
            {
                WriteLine("'{0}' should contain expected card: {1}",
                          description,
                          card);

                Assert.True(array.Any(x => x.ToString() == card.ToString())); // todo need equals

                WriteLine("Found card: {0}",
                          card);
            }
        }

        protected List <ICard> ConvertCardsStringsToList(string cardsAsString)
        {
            var cards = new List <ICard>();

            string[] cardsAStringArray = cardsAsString.Split(',');

            foreach ( string cardAsString in cardsAStringArray )
            {
                cards.Add(StringToCard.ToCard(cardAsString.Trim()));
            }

            return cards;
        }
    }
}