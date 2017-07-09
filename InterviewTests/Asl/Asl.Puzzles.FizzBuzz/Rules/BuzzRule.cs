using Asl.Puzzles.FizzBuzz.Interfaces.Rules;

namespace Asl.Puzzles.FizzBuzz.Rules
{
    public class BuzzRule
        : BaseRule
          ,
          IBuzzRule
    {
        public BuzzRule()
            : base(3)
        {
        }

        protected override bool CheckIfCanApply(int number)
        {
            return number % 5 == 0;
        }

        protected override string GetText(int number)
        {
            return "Buzz";
        }
    }
}