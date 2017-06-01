using PlayinCards.Interfaces.Decks.Cards;
using Rules.Logic.Conditions;
using Rules.Logic.Interfaces.Conditions;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsSuitEqual
        : BaseCondition <ICard>,
          ICondition <ICard>
    {
        public override bool IsSatisfied()
        {
            return Actual.Suit == Threshold.Suit;
        }
    }
}