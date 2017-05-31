using Rules.Logic.Interfaces.Conditions;

namespace Rules.Logic.Conditions
{
    public class IsLessThan
        : BaseCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual < Threshold;
        }
    }
}