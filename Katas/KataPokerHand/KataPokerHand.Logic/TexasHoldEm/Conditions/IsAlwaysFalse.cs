using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsAlwaysFalse // todo testing
        : BaseCardCondition,
          IIsAlwaysFalse
    {
        public override bool IsSatisfied()
        {
            return false;
        }
    }
}