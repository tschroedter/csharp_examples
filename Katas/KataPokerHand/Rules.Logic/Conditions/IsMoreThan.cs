using Rules.Logic.Interfaces.Conditions;

namespace Rules.Logic.Conditions
{
    public class IsMoreThan
        : BaseCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual > Threshold;
        }
    }
}