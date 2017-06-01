using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsAlwaysFalse  // todo testing
        : BaseCardCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return false;
        }
    }
}