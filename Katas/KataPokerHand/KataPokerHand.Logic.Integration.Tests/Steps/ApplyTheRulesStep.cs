using KataPokerHand.Logic.Integration.Tests.Steps.Common;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Steps
{
    [Binding]
    public class ApplyTheRulesStep
        : BaseStep
    {
        [When(@"I apply the rules")]
        public void WhenIApplyTheRules()
        {
            Sut.ApplyRules(new[]
                           {
                               Info
                           });
        }
    }
}