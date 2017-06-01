using Rules.Logic.Interfaces.Conditions;

namespace Rules.Logic.Conditions
{
    public class IsEqual
        : BaseCondition <int>,
          ICondition <int>
    {
        public override bool IsSatisfied()
        {
            return Actual == Threshold;
        }
    }
}