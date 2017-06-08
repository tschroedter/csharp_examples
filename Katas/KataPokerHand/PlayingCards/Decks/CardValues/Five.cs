using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Five
        : BaseCardValue
    {
        public Five()
            : base('5',
                   "Five",
                   new[]
                   {
                       5u
                   },
                   CardRank.Five)
        {
        }
    }
}