using PlayinCards.Interfaces.Decks.Cards;

namespace PlayingCards.Decks.CardValues
{
    public class Two
        : BaseCardValue
    {
        public Two()
            : base('2',
                   "Two",
                   new[]
                   {
                       2u
                   },
                   CardRank.Two)
        {
        }
    }
}