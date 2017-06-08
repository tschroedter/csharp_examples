using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.CardsEngine
{
    [Binding]
    public class CardsRankEngineSteps
    {
        [Given(@"I added a card '(.*)' to player cards")]
        public void GivenIAddedACardToPlayerCards(string cardAsString)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I apply the rules")]
        public void WhenIApplyTheRules()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the status should be '(.*)'")]
        public void ThenTheStatusShouldBe(string statusAsString)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
