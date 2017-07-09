using Asl.Puzzles.FizzBuzz.Interfaces.Rules;

namespace Asl.Puzzles.FizzBuzz.Rules
{
    public class OtherNumberRule
        : BaseRule
          ,
          IOtherNumberRule
    {
        public OtherNumberRule()
            : base(4)
        {
        }

        protected override bool CheckIfCanApply(int number)
        {
            return true;
        }

        protected override string GetText(int number)
        {
            return number.ToString();
        }
    }
}