using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Jack
        : BaseCardValue
    {
        public Jack()
            : base('J',
                   "Jack",
                   new[]
                   {
                       10u
                   },
                   CardRank.Jack)
        {
        }
    }
}