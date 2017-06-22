using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class AddedACardToPlayerCardsStep
        : BaseStep
    {
        [Given(@"I added a card '(.*)' to player cards")]
        public void GivenIAddedACardToPlayerCards(string cardAsString)
        {
            Cards.Add(StringToCard.ToCard(cardAsString));
        }
    }
}