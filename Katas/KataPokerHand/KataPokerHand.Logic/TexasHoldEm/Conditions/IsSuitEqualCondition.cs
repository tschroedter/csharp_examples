using KataPokerHand.Logic.Interfaces.TexasHoldEm.Conditions;
using PlayingCards.Decks.Cards;

namespace KataPokerHand.Logic.TexasHoldEm.Conditions
{
    public class IsSuitEqualCondition
        : BaseCardCondition,
          IIsSuitEqualCondition
    {
        public IsSuitEqualCondition()
        {
            CardOne = UnknownCard.Unknown;
            CardTwo = UnknownCard.Unknown;
        }

        public override bool IsSatisfied()
        {
            return CardOne.Suit == CardTwo.Suit;
        }
    }
}