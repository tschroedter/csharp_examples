namespace KataPokerHand.Logic.Integration.Tests.Example
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Result { get; private set; }

        public void Add()
        {
            Result = FirstNumber + SecondNumber;
        }
    }
}