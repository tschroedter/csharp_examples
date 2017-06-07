using NUnit.Framework;
using TechTalk.SpecFlow;

namespace KataPokerHand.Logic.Integration.Tests.Example
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly Calculator m_Calculator = new Calculator();

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            m_Calculator.SecondNumber = number;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            m_Calculator.FirstNumber = number;
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int number)
        {
            Assert.AreEqual(number,
                            m_Calculator.Result);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            m_Calculator.Add();
        }
    }
}