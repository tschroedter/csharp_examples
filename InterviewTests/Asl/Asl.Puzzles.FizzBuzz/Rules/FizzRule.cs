using Asl.Puzzles.FizzBuzz.Interfaces.Rules;

namespace Asl.Puzzles.FizzBuzz.Rules
{
    public class FizzRule
        : BaseRule
          ,
          IFizzRule
    {
        public FizzRule()
            : base(2)
        {
        }

        protected override bool CheckIfCanApply(int number)
        {
            return number % 3 == 0;
        }

        protected override string GetText(int number)
        {
            return "Fizz";
        }
    }
}