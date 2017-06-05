using PlayinCards.Interfaces.Decks.Cards;
using PlayinCards.Interfaces.Decks.CardValues;

namespace PlayingCards.Decks.CardValues
{
    public class Unknown
        : BaseCardValue
    {
        public Unknown()
            : base("Unknown",
                   new[]
                   {
                       0u
                   },
                   CardRank.Unknown)
        {
        }

        public static ICardValue UnknownCardValue = new Unknown();
    }
}