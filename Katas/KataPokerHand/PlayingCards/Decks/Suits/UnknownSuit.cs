using PlayinCards.Interfaces.Decks.Suits;

namespace PlayingCards.Decks.Suits
{
    public class UnknownSuit
        : BaseSuit
    {
        public static ISuit Unknown = new UnknownSuit();

        public UnknownSuit()
            : base("Unknown")
        {
        }
    }
}