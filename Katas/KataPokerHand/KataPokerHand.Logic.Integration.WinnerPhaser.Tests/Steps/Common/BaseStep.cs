using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataPokerHand.Logic.TexasHoldEm;
using NUnit.Framework;
using PlayinCards.Interfaces;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;
using static System.Console;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps.Common
{
    [Binding]
    public abstract class BaseStep
    {
        protected Dictionary <string, IEnumerable <ICard>> Cards => ( Dictionary <string, IEnumerable <ICard>> )
            ScenarioContext.Current [ "Cards" ];

        protected IStringToCardFactory StringToCard => ( IStringToCardFactory ) ScenarioContext.Current
            [ "StringToCardFactory" ];

        protected IWinnerPhaser Phaser => ( IWinnerPhaser ) ScenarioContext.Current [ "WinnerPhaser" ];

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
    }
}