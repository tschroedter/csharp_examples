using Rules.Logic.Interfaces.Conditions;

namespace Rules.Logic.Conditions
{
    public class IsMoreThan
        : BaseIntegerCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual > Threshold;
        }
    }
}