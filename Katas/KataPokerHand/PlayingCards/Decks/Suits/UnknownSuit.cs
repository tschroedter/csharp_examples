using PlayinCards.Interfaces.Decks.Suits;

namespace PlayingCards.Decks.Suits
{
    public class UnknownSuit
        : BaseSuit
    {
        public UnknownSuit()
            : base("Unknown")
        {
        }

        public static ISuit Unknown = new UnknownSuit();
    }
}