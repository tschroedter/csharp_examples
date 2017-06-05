using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class King
        : BaseCardValue
    {
        public King()
            : base("King",
                   new[]
                   {
                       10u
                   },
                   CardRank.King)
        {
        }
    }
}