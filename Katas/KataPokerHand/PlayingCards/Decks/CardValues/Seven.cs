using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Seven
        : BaseCardValue
    {
        public Seven()
            : base('7',
                   "Seven",
                   new[]
                   {
                       7u
                   },
                   CardRank.Seven)
        {
        }
    }
}