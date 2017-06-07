using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsAlwaysTrue // todo testing
        : BaseCardCondition,
          IIsAlwaysTrue
    {
        public override bool IsSatisfied()
        {
            return true;
        }
    }
}