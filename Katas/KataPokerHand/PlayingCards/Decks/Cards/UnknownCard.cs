using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.Suits;

namespace PlayingCards.Decks.Cards
{
    public class UnknownCard
        : BaseCard <UnknownSuit, CardValues.Unknown>
    {
        public static ICard Unknown = new UnknownCard();
    }
}