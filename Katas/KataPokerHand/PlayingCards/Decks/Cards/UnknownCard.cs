using PlayinCards.Interfaces.Decks.Cards;
using PlayingCards.Decks.CardValues;
using PlayingCards.Decks.Suits;

namespace PlayingCards.Decks.Cards
{
    public class UnknownCard
        : BaseCard <UnknownSuit, Unknown>
    {
        public static ICard Unknown = new UnknownCard();
    }
}