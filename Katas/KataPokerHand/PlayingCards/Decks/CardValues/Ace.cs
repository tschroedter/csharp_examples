using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Ace
        : BaseCardValue
    {
        public Ace()
            : base('A',
                   "Ace",
                   new[]
                   {
                       11u,
                       1u
                   },
                   CardRank.Ace)
        {
        }
    }
}