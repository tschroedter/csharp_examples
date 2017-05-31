using Rules.Logic.Interfaces.Conditions;

namespace Rules.Logic.Conditions
{
    public class IsEqual
        : BaseCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual == Threshold;
        }
    }
}