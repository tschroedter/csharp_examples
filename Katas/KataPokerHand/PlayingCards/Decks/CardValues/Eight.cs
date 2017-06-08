using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Eight
        : BaseCardValue
    {
        public Eight()
            : base('8',
                   "Eight",
                   new[]
                   {
                       8u
                   },
                   CardRank.Eight)
        {
        }
    }
}