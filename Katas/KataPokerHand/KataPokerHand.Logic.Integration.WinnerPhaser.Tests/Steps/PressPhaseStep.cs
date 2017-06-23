using System.Collections.Generic;
using System.Linq;
using KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps.Common;
using PlayinCards.Interfaces.Decks.Cards;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.WinnerPhaser.Tests.Steps
{
    [Binding]
    public class PressPhaseStep
        : BaseStep
    {
        [When(@"I press phase")]
        public void WhenIPressPhase()
        {
            IEnumerable <ICard>[] listOfCards = Cards.Values.ToArray();

            Phaser.Phase(listOfCards);
        }
    }
}