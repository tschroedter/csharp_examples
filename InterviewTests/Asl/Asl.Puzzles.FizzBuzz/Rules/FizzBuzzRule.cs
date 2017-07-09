using Asl.Puzzles.FizzBuzz.Interfaces.Rules;
using JetBrains.Annotations;

namespace Asl.Puzzles.FizzBuzz.Rules
{
    [UsedImplicitly]
    public class FizzBuzzRule
        : BaseRule
          ,
          IFizzBuzzRule
    {
        private readonly IBuzzRule m_BuzzRule;
        private readonly IFizzRule m_FizzRule;

        public FizzBuzzRule(
            [NotNull] IFizzRule fizzRule,
            [NotNull] IBuzzRule buzzRule)
            : base(1)
        {
            m_FizzRule = fizzRule;
            m_BuzzRule = buzzRule;
        }

        protected override bool CheckIfCanApply(int number)
        {
            return m_FizzRule.CanApply(number) && m_BuzzRule.CanApply(number);
        }

        protected override string GetText(int number)
        {
            return "FizzBuzz";
        }
    }
}