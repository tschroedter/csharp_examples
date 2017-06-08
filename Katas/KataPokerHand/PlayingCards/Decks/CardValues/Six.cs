using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Six
        : BaseCardValue
    {
        public Six()
            : base('6',
                   "Six",
                   new[]
                   {
                       6u
                   },
                   CardRank.Six)
        {
        }
    }
}