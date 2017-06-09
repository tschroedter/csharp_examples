using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsAlwaysTrueCondition
        : BaseCardCondition,
          IIsAlwaysTrueCondition
    {
        public override bool IsSatisfied()
        {
            return true;
        }
    }
}