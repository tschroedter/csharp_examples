using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsAlwaysFalseCondition
        : BaseCardCondition,
          IIsAlwaysFalseCondition
    {
        public override bool IsSatisfied()
        {
            return false;
        }
    }
}